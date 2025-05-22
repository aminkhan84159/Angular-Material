using Warehouse.API.DataService.Models;

namespace Warehouse.API.Manager.DTO
{
    public class ProductOutputDTO
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = null!;
        public string Category { get; set; } = null!;
        public decimal Price { get; set; }
        public string Brand { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public int? ChangedBy { get; set; }

        public static ProductOutputDTO MapToEntity(Product product) => new ProductOutputDTO
        {
            ProductId = product.ProductId,
            Title = product.Title,
            Category = product.Category,
            Price = product.Price,
            Brand = product.Brand,
            CreatedOn = product.CreatedOn,
            CreatedBy = product.CreatedBy,
            ChangedOn = product.ChangedOn,
            ChangedBy = product.ChangedBy,
        };
    }
}
