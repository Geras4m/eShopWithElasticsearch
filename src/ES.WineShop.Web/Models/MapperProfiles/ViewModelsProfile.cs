using AutoMapper;
using ES.WineShop.Core.Dto;
using ES.WineShop.Common.Enum;
using ES.WineShop.Common.Extenions;

namespace ES.WineShop.Web.Models.MapperProfile
{
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<ProductDto, ProductViewModel>()
                .ForMember(dest => dest.Category, props => props.MapFrom(src =>
                            src.Category.ToString()))
                .ForMember(dest => dest.Availability, props => props.MapFrom(src =>
                            src.Availability.ToString()));

            CreateMap<ProductViewModel, ProductDto>()
                .ForMember(dest => dest.Category, props => props.MapFrom(src =>
                            src.Category.ToEnum<ProductCategory>(true)))

                .ForMember(dest => dest.Availability, props => props.MapFrom(src =>
                            src.Availability.ToEnum<Availability>(true)));
        }
    }
}
