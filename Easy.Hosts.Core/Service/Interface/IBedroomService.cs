using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.Bedroom;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Service.Interface
{
    public interface IBedroomService
    {
        Task<BedroomReadDto> InsertAsync(BedroomCreateDto bedroom);
        Task<IEnumerable<BedroomReadDto>> FindAllAsync();
        Task<BedroomReadDto> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<BedroomReadDto> UpdateAsync(Guid id, BedroomUpdateDto bedroomUpdateDto);

    }
}
