using Kenan.CodeBaseCodeChallange.Dtos.ProductSaleDtos;
using Kenan.CodeBaseCodeChallange.Entities;

namespace Kenan.CodeBaseCodeChallange.Business.Interfaces
{
    public interface IProductSaleService : IService<ProductSaleCreateDto, ProductSaleListDto, ProductSale>
    {
        Task<bool> CheckStockAsync(ProductSaleCreateDto dto);
        Task<List<ProductSaleListDto>> GetListBetweenTwoDates(DateTime startDate, DateTime endDate);
    }
}
