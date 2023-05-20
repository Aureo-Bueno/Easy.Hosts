
using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Services.Interfaces
{
    public interface IAuthenticateService
    {
        Task Logout();
        Task<UserIdentity> Login(UserLoginDto userLoginDto);
        Task<UserIdentity> ChangePassowod(ChangePasswordDto changePasswordDto);
    }
}
