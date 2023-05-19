using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;
using Easy.Hosts.Core.Services.Interfaces;
using Easy.Hosts.Core.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Easy.Hosts.Controllers
{
    [Route("api/easyhosts/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAuthenticateService _authenticateService;
        public AccountController(ILogger<AccountController> logger, IAuthenticateService authenticateService)
        {
            _logger = logger;
            _authenticateService = authenticateService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDto userRegisterDto)
        {
            UserRegisterDtoValidator validator = new UserRegisterDtoValidator();

            ValidationResult validateUser = await validator.ValidateAsync(userRegisterDto);

            if (validateUser.IsValid)
            {
                User result = await _authenticateService.RegisterUser(userRegisterDto);
                _logger.LogInformation($"User created in {DateTime.Now}, email user: {result.Email}");
                return Ok(result);
            }

            return BadRequest(validateUser);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authenticateService.Logout();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            UserLoginDtoValidator validator = new UserLoginDtoValidator();

            ValidationResult validateUser = await validator.ValidateAsync(userLoginDto);

            if(validateUser.IsValid)
            {
                User result = await _authenticateService.Login(userLoginDto);
                _logger.LogInformation($"User {result.UserName} authenticated");
                return Ok(result);
            }

            return BadRequest(validateUser);
        }

        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            ChangePasswordDtoValidator validator = new ChangePasswordDtoValidator();

            ValidationResult validateChangePassword = await validator.ValidateAsync(changePasswordDto);

            if (validateChangePassword.IsValid)
            {
                User result = await _authenticateService.ChangePassowod(changePasswordDto);
                _logger.LogInformation($"Password updated of user {result.UserName}, hour {DateTime.Now}");
                return Ok(result);

            }

            return BadRequest(validateChangePassword);
        }
    }
}
