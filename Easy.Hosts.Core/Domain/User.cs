using Microsoft.AspNetCore.Identity;

namespace Easy.Hosts.Core.Domain
{
    public class User : IdentityUser
    {
        public string Cpf { get; set; }
    }
}
