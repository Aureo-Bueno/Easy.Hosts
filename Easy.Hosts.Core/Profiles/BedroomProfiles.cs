using AutoMapper;
using Easy.Hosts.Core.DTOs.Bedroom;
using Easy.Hosts.Core.Domain;

namespace Easy.Hosts.Core.Profiles
{
    public class BedroomProfiles : Profile
    {
        public BedroomProfiles()
        {
            //Source -> Target
            CreateMap<Bedroom, BedroomReadDto>();
            CreateMap<BedroomCreateDto, Bedroom>();
        }
    }
}
