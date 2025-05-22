namespace Warehouse.API.Manager.DTO
{
    public class ProductDetailDTO
    {
        public int ProductDetailId { get; set; }
        public int? ProductId { get; set; }
        public string Description { get; set; } = null!;
        public decimal Rating { get; set; }
        public int Stock { get; set; }
        public decimal Weight { get; set; }
        public string Warranty { get; set; } = null!;
    }
}
