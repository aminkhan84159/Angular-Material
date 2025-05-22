using Microsoft.EntityFrameworkCore;
using Warehouse.API.DataService.IDataService;
using Warehouse.API.DataService.Models;

namespace Warehouse.API.DataService.DataService
{
    public class ProductService : IProductService
    {
        private readonly WarehouseContext _context;

        public ProductService(WarehouseContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var res = await _context.Products.ToListAsync();

            return res;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetProductById(int? productId)
        {
            var res = await _context.Products.FindAsync(productId);

            return res;
        }

        public async Task<List<Product>> FilteredProduct(string search)
        {
            var res = await _context.Products.Where(x => x.Title.Contains(search) || x.Category.Contains(search) || x.Brand.Contains(search)).ToListAsync();

            return res;
        }
    }
}
