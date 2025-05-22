namespace Warehouse.API.DataService.Models;

public partial class Product
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

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
}
