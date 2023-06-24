using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Easy.Hosts.Core.Repositories.Interface;
using Easy.Hosts.Core.Enums;
using AutoMapper;
using Easy.Hosts.Core.DTOs.BookingDto;

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
                Status = BookingStatus.Checkin,
                TotalValue = bookingCreatedDto.TotalValue,
                UserId = bookingCreatedDto.UserId,
            };
            await _context.Set<Booking>().AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> FindAllAsync()
        {
            return await _context.Set<Booking>().ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(Guid id)
        {
            return await _context.Set<Booking>().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<BookingReadDto>> GetBookingByUserIdAsync(string id)
        {
            IEnumerable<Booking> result = await _context.Set<Booking>()
                .Include(x => x.Bedroom)
                .Include(x => x.User)
                .Where(x => x.UserId == id && x.Status == BookingStatus.Checkin)
                .ToListAsync();
        
            IEnumerable<BookingReadDto> bookingReadDtos = _mapper.Map<IEnumerable<BookingReadDto>>(result);

            return bookingReadDtos;
        }

        public async Task<BookingReadDto> UpdateStatusCheckoutBooking(Guid id)
        {
            Booking result = await _context.Set<Booking>()
                .FirstOrDefaultAsync(x => x.Id == id);

            result.UpdatedAt = DateTime.Now;
            result.Status = BookingStatus.Checkout;
            await _context.SaveChangesAsync();

            BookingReadDto bookingReadDto = _mapper.Map<BookingReadDto>(result);

            return bookingReadDto;

        }

        public async Task<BookingReadDto> GetByUserIdAsync(Guid id)
        {
            Booking result = await _context.Set<Booking>().Where(x => x.UserId == id.ToString()).FirstOrDefaultAsync();

            BookingReadDto bookingReadDto = _mapper.Map<BookingReadDto>(result);

            return bookingReadDto;
        }

        public async Task<BookingReadDto> GetBookingByUserIdOrderServiceAsync(string id)
        {
            Booking result = await _context.Set<Booking>()
                .Include(x => x.Bedroom)
                .Include(x => x.User)
                .Where(x => x.UserId == id && x.Status == BookingStatus.Checkin)
                .FirstOrDefaultAsync();

            BookingReadDto bookingReadDtos = _mapper.Map<BookingReadDto>(result);

            return bookingReadDtos;
        }
    }
}
