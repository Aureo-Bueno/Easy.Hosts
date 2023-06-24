using Easy.Hosts.Core.Domain.Model;
using Easy.Hosts.Core.Enums;
using System;
using System.Text.Json.Serialization;

namespace Easy.Hosts.Core.Domain
{
    public class OrderService : BaseModel
    {
        public string Description { get; set; }
        public Guid? ProductId { get; set; }
        [JsonIgnore]
        public virtual Product? Product { get; set; }
        public Guid UserId { get; set; }
        public Guid? EmployeeId { get; set; }
        public StatusOrderService Status  { get; set; }
        public OrderServiceType Type { get; set; }
        public Guid? BedroomId { get; set; }
        public virtual Bedroom? Bedroom { get; set; }
    }
}
