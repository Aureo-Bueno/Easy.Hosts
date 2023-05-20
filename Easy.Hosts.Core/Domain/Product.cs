using Easy.Hosts.Core.Domain.Model;

namespace Easy.Hosts.Core.Domain
{
    public class Product : BaseModel
    {
        public OrderService OrderService { get; set; }
    }
}
