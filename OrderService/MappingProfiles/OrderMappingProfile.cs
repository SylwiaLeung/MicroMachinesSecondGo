using AutoMapper;
using OrderService.Models;
using OrderService.Models.Dtos;

namespace OrderService.MappingProfiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderCreateDto, Order>();
            CreateMap<Order, OrderReadDto>().ReverseMap();
        }
    }
}
