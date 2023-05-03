using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.Persistence.Context;
using Easy.Hosts.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Easy.Hosts.Core.Service.Entities
{
    public class BookingService : IBookingService
    {
        private readonly EasyHostsDbContext _context;

        public BookingService(EasyHostsDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Booking booking)
        {
            if (booking == null)
            {
                throw new ArgumentException(nameof(booking));
            }

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
    }
}
