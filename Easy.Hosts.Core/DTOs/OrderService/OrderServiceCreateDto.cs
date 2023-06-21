using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.Enums;
using System;

namespace Easy.Hosts.Core.DTOs.OrderService
{
    public class OrderServiceCreateDto
    {
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public OrderServiceType Type { get; set; }
        public Guid? ProductId { get; set; }
    }
}
