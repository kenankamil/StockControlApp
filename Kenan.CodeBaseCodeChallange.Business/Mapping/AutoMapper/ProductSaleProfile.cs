using AutoMapper;
using Kenan.CodeBaseCodeChallange.Dtos.ProductSaleDtos;
using Kenan.CodeBaseCodeChallange.Entities;

namespace Kenan.CodeBaseCodeChallange.Business.Mapping.AutoMapper
{
    public class ProductSaleProfile : Profile
    {
        public ProductSaleProfile()
        {
            CreateMap<ProductSale, ProductSaleListDto>().ReverseMap();
            CreateMap<ProductSale, ProductSaleCreateDto>().ReverseMap();
        }
    }
}
