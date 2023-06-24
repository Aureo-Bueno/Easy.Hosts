using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.BookingDto;
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
        Task<IEnumerable<BookingReadDto>> GetBookingByUserIdAsync(string id);
        Task<BookingReadDto> UpdateStatusCheckoutBooking(Guid id);
        Task<BookingReadDto> GetBookingByUserIdOrderServiceAsync(string id);
    }
}
