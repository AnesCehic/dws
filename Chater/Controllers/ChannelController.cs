using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chater.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chater.Controllers
{
    [Authorize]
    public class ChannelController : Controller
    {
        private ApplicationDbContext _context;

        public ChannelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("channels")]
        public async Task<ActionResult<IEnumerable<Group>>> GetChannels()
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
        [Route("channels/create")]
        public async Task<ActionResult<Group>> CreateChannel([FromBody] Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            return Ok(group);
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
    }
}