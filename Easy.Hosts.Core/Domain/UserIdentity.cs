using Microsoft.AspNetCore.Identity;

namespace Easy.Hosts.Core.Domain
{
    public class UserIdentity : IdentityUser
    {
        public string Cpf { get; set; }
    }
}
