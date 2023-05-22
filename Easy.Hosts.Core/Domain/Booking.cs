using Easy.Hosts.Core.Domain.Model;
using Easy.Hosts.Core.Enums;
using System;

namespace Easy.Hosts.Core.Domain
{
    public class Booking : BaseModel
    {
        public string CodeBooking { get; set; }
        public BookingStatus Status { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string UserId { get; set; }
        public UserIdentity User { get; set; }
        public Guid BedroomId { get; set; }
        public virtual Bedroom Bedroom { get; set; }
    }
}
