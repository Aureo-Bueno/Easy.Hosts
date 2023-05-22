using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Easy.Hosts.Core.Domain
{
    public class UserIdentity : IdentityUser
    {
        public string Cpf { get; set; }
        public ICollection<Booking> Booking { get; set;}
    }
}
