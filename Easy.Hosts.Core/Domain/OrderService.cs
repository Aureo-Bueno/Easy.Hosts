using Easy.Hosts.Core.Domain.Model;
using Easy.Hosts.Core.Enums;
using System;

namespace Easy.Hosts.Core.Domain
{
    public class OrderService : BaseModel
    {
        public string Description { get; set; }
        public Guid? ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public Guid UserId { get; set; }
        public Guid? EmployeeId { get; set; }
        public StatusOrderService Status  { get; set; }
        public OrderServiceType Type { get; set; }
    }
}
