using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Chater.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chater.Controllers
{
    [Authorize]
    public class ChannelController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public ChannelController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager
            )
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("{userId}/channels")]
        public async Task<ActionResult<IEnumerable<Group>>> GetChannels(string userId)
        {
            return await _context.Groups.ToListAsync();
        }

        [HttpGet]
        [Route("channels/{id}")]
        public async Task<ActionResult<Group>> GetChannelById(string id)
        {
            var group = await _context.Groups.FindAsync(id);

            if(group == null)
            {
                return NotFound(); 
            }

            return group;
        }

        [HttpPost]
        [Route("{userId}/channels/create")]
        public async Task<ActionResult<Group>> CreateChannel(string userId, [FromBody] Group group)
        {
            var user = await _userManager.FindByIdAsync(userId);
            _context.Groups.Add(new Group() { Name = group.Name, User = user });
            await _context.SaveChangesAsync();
            return Ok(group);
            
        }

        [HttpGet]
        [Route("channel/getAllUsers")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //popraviti
        [HttpPut]
        [Route("channels/{id}")]
        public async Task<IActionResult> UpdateChannelById(string id, Group group)
        {
            if(id != group.Id)
            {
                return BadRequest();
            }

            _context.Entry(group).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("channels/{id}")]
        public async Task<IActionResult> DeleteChannelById(string id)
        {
            var group = await _context.Groups.FindAsync(id);

            if(group == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // zavrsiti
        [HttpPost]
        [Route("channel/{id}/addUsers")]
        public async Task<ActionResult> AddUsersToGroup(string id, UserDto userDto)
        {
            Group group = await _context.Groups.FindAsync(id);
            ApplicationUser user = await _userManager.FindByIdAsync(userDto.Id);

            UserGroups userGroups = new UserGroups
            {
                User = user,
                Group = group
            };

            _context.UserGroups.Add(userGroups);

            await _context.SaveChangesAsync();
            return Ok();
        }

        public class UserDto
        {
            [Required]
            public string Id;
        }
    }
}