using AutoMapper;
using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.OrderService;

namespace Easy.Hosts.Core.Profiles
{
    public class OrderServiceProfile : Profile
    {
        public OrderServiceProfile()
        {
            CreateMap<OrderServiceCreateDto, OrderServiceReadDto>().ReverseMap();
            CreateMap<OrderService, OrderServiceReadDto>().ReverseMap();
            CreateMap<OrderServiceUpdateDto, OrderServiceReadDto>().ReverseMap();
        }
    }
}
