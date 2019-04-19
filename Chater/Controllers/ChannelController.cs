using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Chater.Controllers
{
    public class ChannelController : Controller
    {
        [HttpGet]
        [Route("channels")]
        public IActionResult GetChannels()
        {
            return Ok();
        }

        [HttpGet]
        [Route("channels/{id}")]
        public IActionResult GetChannelById(int id)
        {
            return Ok(id);
        }

        [HttpPost]
        [Route("channels/create")]
        public IActionResult CreateChannel()
        {
            return Ok();
        }

        [HttpPut]
        [Route("channels/{id}")]
        public IActionResult UpdateChannelById(int id)
        {
            return Ok(id);
        }

        [HttpDelete]
        [Route("channels/{id}")]
        public IActionResult DeleteChannelById(int id)
        {
            return NoContent();
        }
    }
}