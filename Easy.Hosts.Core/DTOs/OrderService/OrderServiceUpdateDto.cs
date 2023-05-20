using Easy.Hosts.Core.Enums;

namespace Easy.Hosts.Core.DTOs.OrderService
{
    public class OrderServiceUpdateDto
    {
        public string Description { get; set; }
        public StatusOrderService Status { get; set; }
    }
}
