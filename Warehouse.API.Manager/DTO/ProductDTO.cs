namespace Warehouse.API.Manager.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = null!;
        public string Category { get; set; } = null!;
        public decimal Price { get; set; }
        public string Brand { get; set; } = null!;
    }
}
