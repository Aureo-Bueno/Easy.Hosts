using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.DTOs.User
{
    public class UserCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
