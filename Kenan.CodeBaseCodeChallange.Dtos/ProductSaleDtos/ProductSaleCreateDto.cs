using Kenan.CodeBaseCodeChallange.Dtos.Interfaces;

namespace Kenan.CodeBaseCodeChallange.Dtos.ProductSaleDtos
{
    public class ProductSaleCreateDto : IDto
    {
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public int SaleCount { get; set; }
    }
}
