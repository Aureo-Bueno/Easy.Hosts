using Microsoft.AspNetCore.Identity;
using Easy.Hosts.Core.Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Easy.Hosts.Core.Services.Interfaces;
using AutoMapper;
using Easy.Hosts.Core.DTOs.User;

namespace Easy.Hosts.Core.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<UserIdentity> _signInManager;
        public UserService(UserManager<UserIdentity> userManager, IMapper mapper, SignInManager<UserIdentity> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task<List<UserReadDto>> GetAllUserAsync()
        {
            List<UserIdentity> user = await _userManager.Users.ToListAsync();
            List<UserReadDto> userReadDto = _mapper.Map<List<UserReadDto>>(user);
            return userReadDto;
        }

        public async Task<UserReadDto> GetUserByIdAsync(string id)
        {
            UserIdentity user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            UserReadDto userReadDto = _mapper.Map<UserReadDto>(user);
            return userReadDto;
        }

        public async Task<UserIdentity> RegisterUser(UserRegisterDto userRegisterDto)
        {
            UserIdentity user = new()
            {
                UserName = userRegisterDto.Name,
                Email = userRegisterDto.Email,
                Cpf = userRegisterDto.Cpf,
                PhoneNumber = userRegisterDto.NumberPhone
            };

            UserIdentity emailExists = await _userManager.FindByEmailAsync(userRegisterDto.Email);

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
    }
}
