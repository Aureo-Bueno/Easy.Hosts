using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.Enums;
using System;

namespace Easy.Hosts.Core.DTOs.BookingDto
{
    public class BookingReadDto
    {
        public Guid Id { get; set; }
        public string CodeBooking { get; set; }
        public BookingStatus Status { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string UserId { get; set; }
        public UserIdentity User { get; set; }
        public string BedroomId { get; set; }
        public virtual Bedroom Bedroom { get; set; }
    }
}
