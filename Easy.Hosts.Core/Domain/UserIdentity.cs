using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Easy.Hosts.Core.Domain
{
    public class UserIdentity : IdentityUser
    {
        public string Cpf { get; set; }
        [JsonIgnore]
        public ICollection<Booking> Booking { get; set;}
    }
}
