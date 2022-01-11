using AutoMapper;
using Shared.Models;
using UserService.Models;

namespace UserService.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserReadDto>().ReverseMap();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
