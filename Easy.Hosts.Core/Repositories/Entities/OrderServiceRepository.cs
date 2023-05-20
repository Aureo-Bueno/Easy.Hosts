using AutoMapper;
using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.Bedroom;
using Easy.Hosts.Core.DTOs.OrderService;
using Easy.Hosts.Core.Persistence.Context;
using Easy.Hosts.Core.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Repositories.Entities
{
    public class OrderServiceRepository : IOrderServiceRepository
    {
        private readonly EasyHostsDbContext _context;
        private readonly IMapper _mapper;
        public OrderServiceRepository(EasyHostsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderServiceReadDto> InsertAsync(OrderServiceCreateDto orderServiceCreateDto)
        {
            OrderService orderService = new()
            {
                Id = Guid.NewGuid(),
                Description = orderServiceCreateDto.Description,
                EmployeeId = orderServiceCreateDto.EmployeeId,
                Status = orderServiceCreateDto.Status,
                Type = orderServiceCreateDto.Type,
                UserId = orderServiceCreateDto.UserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _context.OrderService.AddAsync(orderService);
            await _context.SaveChangesAsync();

            OrderServiceReadDto orderServiceReadDto = _mapper.Map<OrderServiceReadDto>(orderService);
            return orderServiceReadDto;
        }

        public async Task<IEnumerable<OrderServiceReadDto>> FindAllAsync()
        {
            IEnumerable<OrderService> result = await _context.OrderService.ToListAsync();

            IEnumerable<OrderServiceReadDto> orderServiceReadDtos = _mapper.Map<IEnumerable<OrderServiceReadDto>>(result);
            return orderServiceReadDtos;
        }

        public async Task<OrderServiceReadDto> GetByIdAsync(Guid id)
        {
            OrderService result = await _context.OrderService.FirstOrDefaultAsync(f => f.Id == id);

            OrderServiceReadDto orderServiceReadDto = _mapper.Map<OrderServiceReadDto>(result);
            return orderServiceReadDto;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            OrderService result = await _context.OrderService.FirstOrDefaultAsync(f => f.Id == id);

            _context.Remove(result);
            _context.SaveChanges();
            return true;
        }

        public async Task<OrderServiceReadDto> UpdateAsync(Guid id, OrderServiceUpdateDto orderServiceUpdateDto)
        {
            OrderService orderService = new()
            {
                Id = Guid.NewGuid(),
                UpdatedAt = DateTime.Now,
                Description = orderServiceUpdateDto.Description,
                Status = orderServiceUpdateDto.Status,
            };

            _context.OrderService.Update(orderService);
            await _context.SaveChangesAsync();

            OrderServiceReadDto orderServiceReadDto = _mapper.Map<OrderServiceReadDto>(orderService);
            return orderServiceReadDto;
        }
    }
}
