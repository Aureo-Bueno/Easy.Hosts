using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.DTOs.Booking
{
    public class BookingCreateDto
    {
        public string CodeBooking { get; set; }
        public BookingStatus Status { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string UserId { get; set; }
        public string BedroomId { get; set; }
    }
}
