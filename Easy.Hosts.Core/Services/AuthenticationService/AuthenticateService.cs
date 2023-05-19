using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;
using Easy.Hosts.Core.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Services.AuthenticationService
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthenticateService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<User> RegisterUser(UserRegisterDto userRegisterDto)
        {
            User user = new()
            {
                UserName = userRegisterDto.Email,
                Email = userRegisterDto.Email,
                Cpf = userRegisterDto.Cpf
            };

            User emailExists = await _userManager.FindByEmailAsync(userRegisterDto.Email.ToUpper());

            if (emailExists is null)
            {
                IdentityResult result = await _userManager.CreateAsync(user, userRegisterDto.Password);

                await _userManager.AddToRoleAsync(user, userRegisterDto.RoleName);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return user;
                }
            }
            return null;
        }

        public async Task Logout()
        {
           await _signInManager.SignOutAsync();
        }

        public async Task<User> Login(UserLoginDto userLoginDto)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(userLoginDto.Email, userLoginDto.Password, userLoginDto.RememberMe, false);

            if (result.Succeeded)
            {
                User resultUser = await _userManager.FindByEmailAsync(userLoginDto.Email);
                return resultUser;
            }

            return null;
        }

        public async Task<User> ChangePassowod(ChangePasswordDto changePasswordDto)
        {
            User user = await _userManager.FindByIdAsync(changePasswordDto.UserId);

            IdentityResult result = await _userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);

            if (result.Succeeded)
            {
                return user;
            }

            return null;
        }
    }
}
