using Warehouse.API.DataService.Models;

namespace Warehouse.API.DataService.IDataService
{
    public interface IProductDetailService
    {
        Task<List<ProductDetail>> GetAllProductDetails();
        Task<ProductDetail> AddProductDetail(ProductDetail ProductDetail);
        Task<ProductDetail> UpdateProductDetail(ProductDetail ProductDetail);
        Task<ProductDetail> DeleteProductDetail(ProductDetail ProductDetail);
        Task<ProductDetail> GetProductDetailById(int ProductDetailId);
        Task<ProductDetail> GetProductDetailByProductId(int productId);
    }
}
