using AutoMapper;
using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;
using Easy.Hosts.Core.DTOs.UserRole;
using Easy.Hosts.Core.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Services.AuthenticationService
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly IMapper _mapper;
        public AuthenticateService(SignInManager<UserIdentity> signInManager, UserManager<UserIdentity> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task Logout()
        {
           await _signInManager.SignOutAsync();
        }

        public async Task<UserRoleRead> Login(UserLoginDto userLoginDto)
        {
            UserIdentity resultUser = await _userManager.FindByEmailAsync(userLoginDto.Email);

            if (resultUser is not null)
            {
                IList<string> resultRole = await _userManager.GetRolesAsync(resultUser);
                SignInResult resultLogin = await _signInManager.PasswordSignInAsync(resultUser, userLoginDto.Password, true, false);
                if(resultLogin.Succeeded)
                {
                    UserRoleRead userRoleRead = new()
                    {
                        User = resultUser,
                        Role = resultRole,
                    };
                    return userRoleRead;
                }
            }

            return null;
        }

        public async Task<UserIdentity> ChangePassword(ChangePasswordDto changePasswordDto)
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
