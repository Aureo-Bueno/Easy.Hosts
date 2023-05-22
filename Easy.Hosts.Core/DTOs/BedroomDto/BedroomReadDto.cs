using System;

namespace Easy.Hosts.Core.DTOs.BedroomDto
{
    public class BedroomReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
