using AutoMapper;
using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;
using Easy.Hosts.Core.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Easy.Hosts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers()
        {
            var userItens = await _userService.FindAllAsync();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItens));
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<UserReadDto>>  GetUserById(int id)
        {
            var userItem = await _userService.GetByIdAsync(id);

            if (userItem != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userItem));
            }

            return NotFound();
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<UserReadDto>> CreatePlatForm(UserCreateDto userCreateDto)
        {
            var userCreate = _mapper.Map<User>(userCreateDto);

            await _userService.InsertAsync(userCreate);

            var userReadDto = _mapper.Map<UserReadDto>(userCreate);

            return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDto.Id }, userReadDto);

        }
    }
}
