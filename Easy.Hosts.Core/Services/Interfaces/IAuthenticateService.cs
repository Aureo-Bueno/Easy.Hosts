
using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;
using Easy.Hosts.Core.DTOs.UserRole;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Services.Interfaces
{
    public interface IAuthenticateService
    {
        Task Logout();
        Task<UserRoleRead> Login(UserLoginDto userLoginDto);
        Task<UserIdentity> ChangePassword(ChangePasswordDto changePasswordDto);
    }
}
