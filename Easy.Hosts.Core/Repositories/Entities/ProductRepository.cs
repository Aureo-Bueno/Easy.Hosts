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
    public class ProductRepository : IProductRepository
    {
        private readonly EasyHostsDbContext _context;

        public ProductRepository(EasyHostsDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentException(nameof(product));
            }

            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> FindAllAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Product.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
