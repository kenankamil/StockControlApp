using Kenan.CodeBaseCodeChallange.Dtos.Interfaces;

namespace Kenan.CodeBaseCodeChallange.Dtos.ProductDtos
{
    public class ProductCreateDto : IDto
    {
        public string? ProductName { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
