using Kenan.CodeBaseCodeChallange.Dtos.Interfaces;

namespace Kenan.CodeBaseCodeChallange.Dtos.ProductDtos
{
    public class ProductListDto : IDto
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
