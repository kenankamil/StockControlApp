using AutoMapper;
using Kenan.CodeBaseCodeChallange.Dtos.ProductDtos;
using Kenan.CodeBaseCodeChallange.Entities;

namespace Kenan.CodeBaseCodeChallange.Business.Mapping.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();

            CreateMap<ProductUpdateDto, ProductListDto>().ReverseMap();
        }
    }
}
