using Microsoft.AspNetCore.Identity;
using Easy.Hosts.Core.Domain;

namespace Easy.Hosts.Core.Services.User
{
    public class UserService
    {
        private readonly UserManager<User> _userManager;
        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
    }
}
