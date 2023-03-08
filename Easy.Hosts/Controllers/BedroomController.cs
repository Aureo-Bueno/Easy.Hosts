using AutoMapper;
using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.Bedroom;
using Easy.Hosts.Core.Events;
using Easy.Hosts.Core.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easy.Hosts.Controllers
{
    [Route("api/easyhosts/[controller]")]
    [ApiController]
    public class BedroomController : ControllerBase
    {
        private readonly IBedroomService _bedroomService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public BedroomController(IBedroomService bedroomService, IMapper mapper, ILogger<BedroomController> logger)
        {
            _bedroomService = bedroomService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{id}", Name = "GetBedroomById")]
        public async Task<ActionResult<BedroomReadDto>> GetBedroomById(int id)
        {
            var bedroomItem = await _bedroomService.GetByIdAsync(id);

            if (bedroomItem != null)
            {
                _logger.LogWarning(MyLogEvents.GetItem, "Geting item: ({Id})", id);
                return Ok(_mapper.Map<BedroomReadDto>(bedroomItem));
            }

            _logger.LogWarning(MyLogEvents.GetItemNotFound, "Get({Id}) NOT FOUND", id);
            return NotFound(bedroomItem);
        }

        [HttpPost("insertBedroom")]
        public async Task<ActionResult<BedroomReadDto>> InsertBedroom(BedroomCreateDto bedroomCreateDto)
        {
            var bedroomCreate = _mapper.Map<Bedroom>(bedroomCreateDto);

            await _bedroomService.InsertAsync(bedroomCreate);

            var bedroomReadDto = _mapper.Map<BedroomReadDto>(bedroomCreate);

            _logger.LogWarning(MyLogEvents.InsertItem, "Insert item: ({_bedroomService})", _bedroomService);

            return CreatedAtRoute(nameof(GetBedroomById), new { Id = bedroomReadDto.Id }, bedroomReadDto);
        }

        [HttpGet("getBedrooms")]
        public async Task<ActionResult<IEnumerable<BedroomReadDto>>> GetBedroom()
        {
            var bedroomsItens = await _bedroomService.FindAllAsync();

            return Ok(_mapper.Map<IEnumerable<BedroomReadDto>>(bedroomsItens));
        }
    }
}
