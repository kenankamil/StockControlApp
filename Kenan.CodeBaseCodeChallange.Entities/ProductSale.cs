namespace Kenan.CodeBaseCodeChallange.Entities
{
    public class ProductSale : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string CustomerName { get; set; }
        public int SaleCount { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
