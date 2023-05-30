using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;
using Easy.Hosts.Core.DTOs.UserRole;
using Easy.Hosts.Core.Events;
using Easy.Hosts.Core.Services.Interfaces;
using Easy.Hosts.Core.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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
                UserRoleRead result = await _authenticateService.Login(userLoginDto);
                _logger.LogInformation(MyLogEvents.GetItem,$"User {result.User.UserName} authenticated");
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
                UserIdentity result = await _authenticateService.ChangePassword(changePasswordDto);
                _logger.LogInformation(MyLogEvents.UpdateItem,$"Password updated of user {result.UserName}, hour {DateTime.Now}");
                return Ok(result);

            }

            return BadRequest(validateChangePassword);
        }
    }
}
