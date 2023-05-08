using Easy.Hosts.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Repositories.Interface
{
    public interface ITypeBedroomRepository
    {
        Task InsertAsync(TypeBedroom typeBedroom);
        Task<IEnumerable<TypeBedroom>> FindAllAsync();
        Task<TypeBedroom> GetByIdAsync(Guid id);
    }
}
