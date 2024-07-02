

using AutoMapper;
using Cores.DToS;
using Cores.Entities;
using Cores.Helpers;

namespace Cores.Mappers
{
    public class MappingProfile:Profile
    {
        
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(m => m.ProductBrand.Name))
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(m => m.ProductType.Name));
            CreateMap<CustomerBusket, CustomerDto>().ReverseMap();
            CreateMap<BasketItem,BasketItemDto>().ReverseMap();
        }
    }
}
