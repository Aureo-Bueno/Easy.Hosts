using Easy.Hosts.Core.DTOs.OrderServiceDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Repositories.Interface
{
    public interface IOrderServiceRepository
    {
        Task<OrderServiceReadDto> InsertAsync(OrderServiceCreateDto bedroom);
        Task<IEnumerable<OrderServiceReadDto>> FindAllAsync();
        Task<OrderServiceReadDto> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<OrderServiceReadDto> UpdateAsync(Guid id, OrderServiceUpdateDto bedroomUpdateDto);
        Task<OrderServiceReadDto> AssignEmployeOrderServiceAsync(Guid id, OrderServiceAssignDto orderServiceAssignDto);
        Task<List<OrderServiceReadDto>> GetOrderServiceByUserId(Guid id);
    }
}
