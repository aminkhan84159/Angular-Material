namespace Warehouse.API.DataService.Models;

public partial class ProductDetail
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

    public virtual Product? Product { get; set; }
}
