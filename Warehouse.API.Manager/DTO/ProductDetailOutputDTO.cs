using Warehouse.API.DataService.Models;

namespace Warehouse.API.Manager.DTO
{
    public class ProductDetailOutputDTO
    {
        public int ProductDetailId { get; set; }
        public int? ProductId { get; set; }
        public string Description { get; set; } = null!;
        public decimal Rating { get; set; }
        public int Stock { get; set; }
        public decimal Weight { get; set; }
        public string Warranty { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public int? ChangedBy { get; set; }

        public static ProductDetailOutputDTO MapToEntity(ProductDetail productDetail) => new ProductDetailOutputDTO
        {
            ProductDetailId = productDetail.ProductDetailId,
            ProductId = productDetail.ProductId,
            Description = productDetail.Description,
            Rating = productDetail.Rating,
            Stock = productDetail.Stock,
            Weight = productDetail.Weight,
            Warranty = productDetail.Warranty,
            CreatedOn = productDetail.CreatedOn,
            ChangedOn = productDetail.ChangedOn,
            ChangedBy = productDetail.ChangedBy,
            CreatedBy = productDetail.CreatedBy
        };
    }
}
