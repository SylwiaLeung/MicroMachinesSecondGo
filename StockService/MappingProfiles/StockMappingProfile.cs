using AutoMapper;
using StockService.Models.Dtos;
using StockService.Models.Entities;

namespace StockService.MappingProfiles
{
    public class StockMappingProfile : Profile
    {
        public StockMappingProfile()
        {
            CreateMap<Stock, StockReadDto>();
            CreateMap<Category, CategoryReadDto>();
            CreateMap<Product, ProductReadDto>()
                .ForMember(x => x.CategoryName, r => r.MapFrom(p => p.Category.Name))
                .ForMember(x => x.StockName, r => r.MapFrom(p => p.Stock.Name));
        }
    }
}
