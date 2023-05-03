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
    public class BedroomService : IBedroomService
    {
        private readonly EasyHostsDbContext _context;

        public BedroomService(EasyHostsDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Bedroom bedroom)
        {
            if (bedroom == null)
            {
                throw new ArgumentException(nameof(bedroom));
            }

            Bedroom bedromNew = new()
            {
                Id = Guid.NewGuid(),
                Name = bedroom.Name,
                Number = bedroom.Number,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _context.Bedroom.AddAsync(bedromNew);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bedroom>> FindAllAsync()
        {
            return await _context.Bedroom.ToListAsync();
        }

        public async Task<Bedroom> GetByIdAsync(Guid id)
        {
            return await _context.Bedroom.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
