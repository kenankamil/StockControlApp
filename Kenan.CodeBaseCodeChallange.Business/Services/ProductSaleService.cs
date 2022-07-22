using AutoMapper;
using FluentValidation;
using Kenan.CodeBaseCodeChallange.Business.Interfaces;
using Kenan.CodeBaseCodeChallange.DataAccess.UnitOfWork;
using Kenan.CodeBaseCodeChallange.Dtos.ProductDtos;
using Kenan.CodeBaseCodeChallange.Dtos.ProductSaleDtos;
using Kenan.CodeBaseCodeChallange.Entities;

namespace Kenan.CodeBaseCodeChallange.Business.Services
{
    public class ProductSaleService : Service<ProductSaleCreateDto, ProductSaleListDto, ProductSale>, IProductSaleService
    {
        private readonly IMapper _mapper;
        private readonly IUoW _uoW;
        private readonly IProductService _productService;
        public ProductSaleService(IMapper mapper, IUoW uoW, IProductService productService) : base(mapper, uoW)
        {
            _mapper = mapper;
            _uoW = uoW;
            _productService = productService;
        }

        public async Task<bool> CheckStockAsync(ProductSaleCreateDto dto)
        {
            var product = await _productService.GetByIdAsync<ProductListDto>(dto.ProductId);
            return dto.SaleCount < product.Stock;
        }

        public async Task<List<ProductSaleListDto>> GetListBetweenTwoDates(DateTime startDate, DateTime endDate)
        {
            var data = await _uoW.GetRepository<ProductSale>().GetListByFilterAsync(x => x.CreatedAt > startDate && x.CreatedAt < endDate);
            var dto = _mapper.Map<List<ProductSaleListDto>>(data);
            return dto;
        }
    }
}
