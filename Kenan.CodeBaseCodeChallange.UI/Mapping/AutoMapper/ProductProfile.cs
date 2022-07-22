using AutoMapper;
using Kenan.CodeBaseCodeChallange.Dtos.ProductDtos;
using Kenan.CodeBaseCodeChallange.UI.Models;

namespace Kenan.CodeBaseCodeChallange.UI.Mapping.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateModel, ProductListDto>().ReverseMap();
            CreateMap<ProductCreateModel, ProductCreateDto>().ReverseMap();
            CreateMap<ProductCreateModel, ProductUpdateDto>().ReverseMap();

            CreateMap<ProductUpdateModel, ProductListDto>().ReverseMap();
            CreateMap<ProductUpdateModel, ProductCreateDto>().ReverseMap();
            CreateMap<ProductUpdateModel, ProductUpdateDto>().ReverseMap();
        }
    }
}
