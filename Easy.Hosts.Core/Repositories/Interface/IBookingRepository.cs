using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.Booking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Repositories.Interface
{
    public interface IBookingRepository
    {
        Task InsertAsync(BookingCreateDto bookingCreatedDto);
        Task<IEnumerable<Booking>> FindAllAsync();
        Task<Booking> GetByIdAsync(Guid id);
        Task<List<BookingReadDto>> GetBookingByUserIdAsync(string id);
    }
}
