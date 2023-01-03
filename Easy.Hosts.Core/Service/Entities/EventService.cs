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
    public class EventService : IEventService
    {
        private readonly EasyHostsDbContext _context;

        public EventService(EasyHostsDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Event @event)
        {
            if (@event == null)
            {
                throw new ArgumentException(nameof(@event));
            }

            await _context.Event.AddAsync(@event);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> FindAllAsync()
        {
            return await _context.Event.ToListAsync();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _context.Event.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
