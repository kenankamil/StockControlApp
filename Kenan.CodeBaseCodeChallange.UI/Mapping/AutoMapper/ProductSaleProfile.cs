using AutoMapper;
using Kenan.CodeBaseCodeChallange.Dtos.ProductSaleDtos;
using Kenan.CodeBaseCodeChallange.UI.Models;

namespace Kenan.CodeBaseCodeChallange.UI.Mapping.AutoMapper
{
    public class ProductSaleProfile : Profile
    {
        public ProductSaleProfile()
        {
            CreateMap<ProductSaleCreateModel, ProductSaleCreateDto>().ReverseMap();
            CreateMap<ProductSaleCreateModel, ProductSaleListDto>().ReverseMap();
        }
    }
}
