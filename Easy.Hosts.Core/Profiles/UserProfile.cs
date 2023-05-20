using AutoMapper;
using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.User;

namespace Easy.Hosts.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserIdentity, UserReadDto>().ReverseMap();
        }
    }
}
