using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.Persistence.Context;
using Easy.Hosts.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Easy.Hosts.Core.DTOs.Bedroom;
using AutoMapper;

namespace Easy.Hosts.Core.Service.Entities
{
    public class BedroomService : IBedroomService
    {
        private readonly EasyHostsDbContext _context;
        private readonly IMapper _mapper;

        public BedroomService(EasyHostsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BedroomReadDto> InsertAsync(BedroomCreateDto bedroom)
        {
            Bedroom bedromNew = new()
            {
                Id = Guid.NewGuid(),
                Name = bedroom.Name,
                Number = bedroom.Number,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _context.Bedroom.AddAsync(bedromNew);
            await _context.SaveChangesAsync();

            BedroomReadDto bedroomReadDto = _mapper.Map<BedroomReadDto>(bedromNew);
            return bedroomReadDto;
        }

        public async Task<IEnumerable<BedroomReadDto>> FindAllAsync()
        {
            IEnumerable<Bedroom> result = await _context.Bedroom.ToListAsync();

            IEnumerable<BedroomReadDto> bedroomReadDtos = _mapper.Map<IEnumerable<BedroomReadDto>>(result);
            return bedroomReadDtos;
        }

        public async Task<BedroomReadDto> GetByIdAsync(Guid id)
        {
            Bedroom result = await _context.Bedroom.FirstOrDefaultAsync(f => f.Id == id);

            BedroomReadDto bedroomReadDto = _mapper.Map<BedroomReadDto>(result);
            return bedroomReadDto;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Bedroom result = await _context.Bedroom.FirstOrDefaultAsync(f => f.Id == id);

            _context.Remove(result);
            _context.SaveChanges();
            return true;
        }

        public async Task<BedroomReadDto> UpdateAsync(Guid id, BedroomUpdateDto bedroomUpdateDto)
        {
            Bedroom bedromUpdate = new()
            {
                Name = bedroomUpdateDto.Name,
                Number = bedroomUpdateDto.Number,
                UpdatedAt = DateTime.UtcNow,
            };

            _context.Bedroom.Update(bedromUpdate);
            await _context.SaveChangesAsync();

            BedroomReadDto bedroomReadDto = _mapper.Map<BedroomReadDto>(bedromUpdate);
            return bedroomReadDto;
        }
    }
}
