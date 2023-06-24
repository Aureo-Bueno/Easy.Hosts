
using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;
using Easy.Hosts.Core.Enums;
using System;
using System.Text.Json.Serialization;

namespace Easy.Hosts.Core.DTOs.OrderServiceDto
{
    public class OrderServiceReadDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public Guid EmployeeId { get; set; }
        public StatusOrderService Status { get; set; }
        public OrderServiceType Type { get; set; }
        public Guid? BedroomId { get; set; }
        public virtual Bedroom? Bedroom { get; set; }
        public Guid? ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
