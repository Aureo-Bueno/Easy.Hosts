using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Easy.Hosts.Core.Repositories.Interface;
using Easy.Hosts.Core.Enums;
using Easy.Hosts.Core.DTOs.Booking;
using AutoMapper;

namespace Easy.Hosts.Core.Repositories.Entities
{
    public class BookingRepository : IBookingRepository
    {
        private readonly EasyHostsDbContext _context;
        private readonly IMapper _mapper;
        public BookingRepository(EasyHostsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task InsertAsync(BookingCreateDto bookingCreatedDto)
        {

            Booking booking = new()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                BedroomId = bookingCreatedDto.BedroomId,
                Checkin = bookingCreatedDto.Checkin,
                Checkout = bookingCreatedDto.Checkout,
                CodeBooking = bookingCreatedDto.CodeBooking,
                Status = bookingCreatedDto.Status,
                TotalValue = bookingCreatedDto.TotalValue,
                UserId = bookingCreatedDto.UserId,
            };
            await _context.Booking.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> FindAllAsync()
        {
            return await _context.Booking.ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(Guid id)
        {
            return await _context.Booking.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<BookingReadDto>> GetBookingByUserIdAsync(string id)
        {
            List<Booking> result = await _context.Booking.Where(x => x.UserId == id && x.Status == BookingStatus.Checkin).ToListAsync();
        
            List<BookingReadDto> bookingReadDtos = _mapper.Map<List<BookingReadDto>>(result);

            return bookingReadDtos;
        }
    }
}
