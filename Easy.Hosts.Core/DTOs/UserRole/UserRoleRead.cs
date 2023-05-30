using Easy.Hosts.Core.Domain;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Easy.Hosts.Core.DTOs.UserRole
{
    public class UserRoleRead
    {
        public UserIdentity User { get; set; }
        public IList<string> Role { get; set; }
    }
}
