using Easy.Hosts.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Repositories.Interface
{
    public interface IProductRepository
    {
        Task InsertAsync(Product product);
        Task<IEnumerable<Product>> FindAllAsync();
        Task<Product> GetByIdAsync(Guid id);
    }
}
