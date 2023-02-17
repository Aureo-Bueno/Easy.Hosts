using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easy.Hosts.Controllers
{
    [Route("api/easyhosts/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                // Copia os dados do RegisterViewModel para o IdentityUser
                var user = new User
                {
                    UserName = userRegisterDto.Email,
                    Email = userRegisterDto.Email,
                    Cpf = userRegisterDto.Cpf
                };

                // Armazena os dados do usuário na tabela AspNetUsers
                var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
                // Se o usuário foi criado com sucesso, faz o login do usuário
                // usando o serviço SignInManager e redireciona para o Método Action Index

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok(user);
                }

                // Se houver erros então inclui no ModelState
                // que será exibido pela tag helper summary na validação
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return NotFound(userRegisterDto);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userLoginDto.Email, userLoginDto.Password, userLoginDto.RememberMe, false);
                if (result.Succeeded)
                {
                    return Ok(result);
                }

                ModelState.AddModelError(string.Empty, "Login Inválido");
            }

            return NotFound(returnUrl);
        }
    }
}
