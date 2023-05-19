
using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Services.Interfaces
{
    public interface IAuthenticateService
    {
        Task<User> RegisterUser(UserRegisterDto userRegisterDto);
        Task Logout();
        Task<User> Login(UserLoginDto userLoginDto);
        Task<User> ChangePassowod(ChangePasswordDto changePasswordDto);
    }
}
