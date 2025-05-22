using Microsoft.EntityFrameworkCore;
using Warehouse.API.DataService.IDataService;
using Warehouse.API.DataService.Models;

namespace Warehouse.API.DataService.DataService
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly WarehouseContext _context;

        public ProductDetailService(WarehouseContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDetail>> GetAllProductDetails()
        {
            var res = await _context.ProductDetails.ToListAsync();

            return res;
        }

        public async Task<ProductDetail> AddProductDetail(ProductDetail ProductDetail)
        {
            _context.ProductDetails.Add(ProductDetail);
            await _context.SaveChangesAsync();

            return ProductDetail;
        }

        public async Task<ProductDetail> UpdateProductDetail(ProductDetail ProductDetail)
        {
            _context.ProductDetails.Update(ProductDetail);
            await _context.SaveChangesAsync();

            return ProductDetail;
        }
        public async Task<ProductDetail> DeleteProductDetail(ProductDetail ProductDetail)
        {
            _context.ProductDetails.Remove(ProductDetail);
            await _context.SaveChangesAsync();

            return ProductDetail;
        }

        public async Task<ProductDetail> GetProductDetailById(int ProductDetailId)
        {
            var res = await _context.ProductDetails.FindAsync(ProductDetailId);

            return res;
        }

        public async Task<ProductDetail> GetProductDetailByProductId(int productId)
        {
            var res = await _context.ProductDetails.Where(x => x.ProductId == productId).FirstOrDefaultAsync();

            return res;
        }
    }
}
