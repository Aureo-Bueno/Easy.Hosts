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
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        public AuthenticateService(SignInManager<UserIdentity> signInManager, UserManager<UserIdentity> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task Logout()
        {
           await _signInManager.SignOutAsync();
        }

        public async Task<UserIdentity> Login(UserLoginDto userLoginDto)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(userLoginDto.Email, userLoginDto.Password, userLoginDto.RememberMe, false);

            if (result.Succeeded)
            {
                UserIdentity resultUser = await _userManager.FindByEmailAsync(userLoginDto.Email);
                return resultUser;
            }

            return null;
        }

        public async Task<UserIdentity> ChangePassowod(ChangePasswordDto changePasswordDto)
        {
            UserIdentity user = await _userManager.FindByIdAsync(changePasswordDto.UserId);

            IdentityResult result = await _userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);

            if (result.Succeeded)
            {
                return user;
            }

            return null;
        }
    }
}
