using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Easy.Hosts.Core.Repositories.Interface;

namespace Easy.Hosts.Core.Repositories.Entities
{
    public class EventRepository : IEventRepository
    {
        private readonly EasyHostsDbContext _context;

        public EventRepository(EasyHostsDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Event @event)
        {
            if (@event == null)
            {
                throw new ArgumentException(nameof(@event));
            }

            await _context.Set<Event>().AddAsync(@event);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> FindAllAsync()
        {
            return await _context.Set<Event>().ToListAsync();
        }

        public async Task<Event> GetByIdAsync(Guid id)
        {
            return await _context.Set<Event>().FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
