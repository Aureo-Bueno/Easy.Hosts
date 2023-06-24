using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Repositories.Interface
{
    public interface IProductRepository
    {
        Task InsertAsync(ProductCreate product);
        Task<IEnumerable<Product>> FindAllAsync();
        Task<Product> GetByIdAsync(Guid id);
    }
}
