using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.Bedroom;
using Easy.Hosts.Core.Events;
using Easy.Hosts.Core.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Controllers
{
    [Route("api/easyhosts/[controller]")]
    [ApiController]
    public class BedroomController : ControllerBase
    {
        private readonly IBedroomService _bedroomService;
        private readonly ILogger _logger;
        public BedroomController(IBedroomService bedroomService, ILogger<BedroomController> logger)
        {
            _bedroomService = bedroomService;
            _logger = logger;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            BedroomReadDto result = await _bedroomService.GetByIdAsync(id);
            _logger.LogWarning(MyLogEvents.GetItemNotFound, $"Get({id}) NOT FOUND");
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] BedroomCreateDto bedroomCreateDto)
        {
            BedroomReadDto result = await _bedroomService.InsertAsync(bedroomCreateDto);

            _logger.LogWarning(MyLogEvents.InsertItem, $"Insert item: ({result})");

            return result is not null ? Ok(result) : NoContent();
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<BedroomReadDto> results = await _bedroomService.FindAllAsync();

            return results is not null ? Ok(results) : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool result = await _bedroomService.DeleteAsync(id);
            return result ? Ok() : NotFound();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] BedroomUpdateDto bedroomUpdateDto,Guid id)
        {
            BedroomReadDto result = await _bedroomService.UpdateAsync(id, bedroomUpdateDto);
            return result is not null ? Ok(result) : NotFound();
        }
    }
}
