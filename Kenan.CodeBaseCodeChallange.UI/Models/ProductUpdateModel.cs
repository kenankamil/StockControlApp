namespace Kenan.CodeBaseCodeChallange.UI.Models
{
    public class ProductUpdateModel
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
