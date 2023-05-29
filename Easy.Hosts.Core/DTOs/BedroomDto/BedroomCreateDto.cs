﻿using System.ComponentModel.DataAnnotations;

namespace Easy.Hosts.Core.DTOs.BedroomDto
{
    public class BedroomCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }
    }
}