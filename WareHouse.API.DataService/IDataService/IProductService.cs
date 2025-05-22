using Warehouse.API.DataService.DataService;
using Warehouse.API.DataService.Models;

namespace Warehouse.API.DataService.IDataService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(Product product);
        Task<Product> GetProductById(int? productId);
        Task<List<Product>> FilteredProduct(string search);
    }
}
