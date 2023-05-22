using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Easy.Hosts.Controllers
{
    [Route("api/easyhosts/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet("id:guid")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Insert()
        {
            return Ok();
        }

        [HttpPut("id:guid")]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }

        [HttpDelete("id:guid")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
