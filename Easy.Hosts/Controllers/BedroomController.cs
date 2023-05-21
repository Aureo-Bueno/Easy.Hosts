using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.Bedroom;
using Easy.Hosts.Core.Events;
using Easy.Hosts.Core.Repositories.Interface;
using Easy.Hosts.Core.Validators.Bedroom;
using FluentValidation.Results;
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
        private readonly IBedroomRepository _bedroomRepository;
        private readonly ILogger _logger;
        public BedroomController(IBedroomRepository bedroomRepository, ILogger<BedroomController> logger)
        {
            _bedroomRepository = bedroomRepository;
            _logger = logger;
        }

        [HttpGet("id:guid")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<BedroomReadDto> results = await _bedroomRepository.FindAllAsync();

            foreach (var item in results)
                _logger.LogWarning(MyLogEvents.GetItem, $"Get Bedroom Id: ({item.Id})");

            return results is not null ? Ok(results) : NotFound();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            BedroomReadDto result = await _bedroomRepository.GetByIdAsync(id);
            _logger.LogWarning(MyLogEvents.GetItem, $"Get Bedroom Id: ({id})");
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] BedroomCreateDto bedroomCreateDto)
        {
            BedroomCreateDtoValidator validator = new();

            ValidationResult validate = await validator.ValidateAsync(bedroomCreateDto);

            if (validate.IsValid)
            {
                BedroomReadDto result = await _bedroomRepository.InsertAsync(bedroomCreateDto);

                _logger.LogWarning(MyLogEvents.InsertItem, $"Insert Bedroom item: {result.Id}, {result.Name}");

                return Ok(result);
            }

            return BadRequest(validate.Errors);
          
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] BedroomUpdateDto bedroomUpdateDto,Guid id)
        {
            BedroomUpdateDtoValidator validator = new();

            ValidationResult validate = await validator.ValidateAsync(bedroomUpdateDto);

            if (validate.IsValid)
            {
                BedroomReadDto result = await _bedroomRepository.UpdateAsync(id, bedroomUpdateDto);
                _logger.LogWarning(MyLogEvents.UpdateItem, $"Updated Bedroom Id: ({id})");
                return Ok(result);
            }

            return BadRequest(validate.Errors);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool result = await _bedroomRepository.DeleteAsync(id);
            _logger.LogWarning(MyLogEvents.DeleteItem, $"Deleted Bedroom Id: ({id})");
            return result ? Ok() : NotFound();
        }
    }
}
