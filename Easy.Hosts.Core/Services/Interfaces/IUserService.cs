using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserReadDto>> GetAllUserAsync();
        Task<UserReadDto> GetUserByIdAsync(string id);
        Task<UserIdentity> RegisterUser(UserRegisterDto userRegisterDto);

    }
}
