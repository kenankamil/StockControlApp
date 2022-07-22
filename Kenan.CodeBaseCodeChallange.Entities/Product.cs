namespace Kenan.CodeBaseCodeChallange.Entities
{
    public class Product : BaseEntity
    {
        public string? ProductName { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<ProductSale> ProductSales { get; set; }
    }
}
