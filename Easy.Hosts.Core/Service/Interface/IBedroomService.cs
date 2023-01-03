using Easy.Hosts.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Service.Interface
{
    public interface IBedroomService
    {
        Task InsertAsync(Bedroom bedroom);
        Task<IEnumerable<Bedroom>> FindAllAsync();
        Task<Bedroom> GetByIdAsync(int id);
    }
}
