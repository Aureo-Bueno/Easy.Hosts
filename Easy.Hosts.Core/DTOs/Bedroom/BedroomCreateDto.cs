using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.DTOs.Bedroom
{
    public class BedroomCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
