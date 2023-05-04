using System.ComponentModel.DataAnnotations;

namespace Easy.Hosts.Core.DTOs.Bedroom
{
    public class BedroomUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
