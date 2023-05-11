using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;
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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDto userRegisterDto)
        {
            UserRegisterDtoValidator validator = new UserRegisterDtoValidator();

            ValidationResult validateUser = await validator.ValidateAsync(userRegisterDto);

            if (validateUser.IsValid)
            {
                User user = new()
                {
                    UserName = userRegisterDto.Email,
                    Email = userRegisterDto.Email,
                    Cpf = userRegisterDto.Cpf
                };


                IdentityResult result = await _userManager.CreateAsync(user, userRegisterDto.Password);
                _logger.LogInformation($"User created! Info: {user.Email}, {DateTime.UtcNow}");


                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok(user);
                }
            }

            return BadRequest(validateUser);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            UserLoginDtoValidator validator = new UserLoginDtoValidator();

            ValidationResult validateUser = await validator.ValidateAsync(userLoginDto);

            if(validateUser.IsValid)
            {

                SignInResult result = await _signInManager.PasswordSignInAsync(userLoginDto.Email, userLoginDto.Password, userLoginDto.RememberMe, false);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
            }

            return NotFound();
        }
    }
}
