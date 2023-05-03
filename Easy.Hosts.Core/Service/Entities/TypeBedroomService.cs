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
    public class TypeBedroomService : ITypeBedroomService
    {
        private readonly EasyHostsDbContext _context;

        public TypeBedroomService(EasyHostsDbContext context)
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
