using Easy.Hosts.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Service.Interface
{
    public interface ITypeBedroomService
    {
        Task InsertAsync(TypeBedroom typeBedroom);
        Task<IEnumerable<TypeBedroom>> FindAllAsync();
        Task<TypeBedroom> GetByIdAsync(int id);
    }
}
