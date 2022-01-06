using AutoMapper;
using MicroMachines.Entities;
using MicroMachines.Models.Dtos;

namespace MicroMachines.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserReadDto>();
        }
    }
}
