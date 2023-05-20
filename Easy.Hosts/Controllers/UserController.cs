using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;
using Easy.Hosts.Core.Services.AuthenticationService;
using Easy.Hosts.Core.Services.Interfaces;
using Easy.Hosts.Core.Validators;
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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            UserRegisterDtoValidator validator = new UserRegisterDtoValidator();

            ValidationResult validateUser = await validator.ValidateAsync(userRegisterDto);

            if (validateUser.IsValid)
            {
                UserIdentity result = await _userService.RegisterUser(userRegisterDto);
                _logger.LogInformation($"User created in {DateTime.Now}, email user: {result.Email}");
                return Ok(result);
            }

            return BadRequest(validateUser);
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            List<UserReadDto> result = await _userService.GetAllUserAsync();

            return Ok(result);
        }

        [HttpGet("id:string")]
        public async Task<IActionResult> GetId(string id)
        {
            UserReadDto result = await _userService.GetUserByIdAsync(id);

            return Ok(result);
        }
    }
}
