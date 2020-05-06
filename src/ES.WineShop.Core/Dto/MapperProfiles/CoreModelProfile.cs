using AutoMapper;
using ES.WineShop.Common.Enum;
using ES.WineShop.Data.Entities;

namespace ES.WineShop.Core.Dto.MapperProfile
{
    public class CoreModelProfile : Profile
    {
        public CoreModelProfile()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();
        }
    }
}
