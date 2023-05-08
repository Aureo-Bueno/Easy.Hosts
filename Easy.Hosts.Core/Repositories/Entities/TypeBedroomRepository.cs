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
    public class TypeBedroomRepository : ITypeBedroomRepository
    {
        private readonly EasyHostsDbContext _context;

        public TypeBedroomRepository(EasyHostsDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(TypeBedroom typeBedroom)
        {
            if (typeBedroom == null)
            {
                throw new ArgumentException(nameof(typeBedroom));
            }

            await _context.TypeBedroom.AddAsync(typeBedroom);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TypeBedroom>> FindAllAsync()
        {
            return await _context.TypeBedroom.ToListAsync();
        }

        public async Task<TypeBedroom> GetByIdAsync(Guid id)
        {
            return await _context.TypeBedroom.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
