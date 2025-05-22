using Warehouse.API.DataService.DataService;
using Warehouse.API.DataService.IDataService;
using Warehouse.API.DataService.Models;
using Warehouse.API.Manager.DTO;
using Warehouse.API.Manager.Exceptions;

namespace Warehouse.API.Manager.Manager
{
    public class ProductDetailManager
    {
        private readonly IProductDetailService _productDetailService;
        private readonly IProductService _productService;

        public ProductDetailManager(
            IProductDetailService productDetailService,
            IProductService productService
            )
        {
            _productDetailService = productDetailService;
        }

        public async Task<List<ProductDetailOutputDTO>> GetAllProductDetails()
        {
            Dictionary<string, string> exceptions = new Dictionary<string, string>();

            var productDetail = await _productDetailService.GetAllProductDetails();

            if (productDetail == null)
            {
                exceptions.Add("no products", "No products");

                throw new CustomException(exceptions);
            }
            else
            {
                var res = productDetail.Select(x => ProductDetailOutputDTO.MapToEntity(x)).ToList();

                return res;
            }
        }

        public async Task<ProductDetailOutputDTO> AddProductDetail(ProductDetailDTO productDetailDTO)
        {
            Dictionary<string, string> exceptions = new Dictionary<string, string>();

            var product = _productService.GetProductById(productDetailDTO.ProductId);

            if (product != null)
            {
                if (string.IsNullOrWhiteSpace(productDetailDTO.Description))
                    exceptions.Add("Description missing", "Description can't be empty");

                if (productDetailDTO.Rating < 0)
                    exceptions.Add("rating", "Rating can't be negative");

                if (productDetailDTO.Rating > 10)
                    exceptions.Add("Rating", "rate between 1 to 10");

                if(productDetailDTO.Stock < 0)
                    exceptions.Add("stock", "Stock can't be in negative");

                if (productDetailDTO.Weight < 0)
                    exceptions.Add("Weight", "weight can't be negative");

                if (string.IsNullOrWhiteSpace(productDetailDTO.Warranty))
                    exceptions.Add("warranty", "warranty can't be empty");

                if (exceptions.Count == 0)
                {
                    var ProductDetail = new ProductDetail
                    {
                        ProductId = productDetailDTO.ProductId,
                        Description = productDetailDTO.Description,
                        Rating = productDetailDTO.Rating,
                        Stock = productDetailDTO.Stock,
                        Weight = productDetailDTO.Weight,
                        Warranty = productDetailDTO.Warranty,
                        CreatedOn = DateTime.Now,
                    };

                    await _productDetailService.AddProductDetail(ProductDetail);
                    return ProductDetailOutputDTO.MapToEntity(ProductDetail);
                }
                else
                {
                    throw new CustomException(exceptions);
                }
            }
            else
            {
                exceptions.Add("ProductId Invalid", "Product with this Id doesn't exist");

                throw new CustomException(exceptions);
            }
        }

        public async Task<ProductDetailOutputDTO> UpdateProductDetail(ProductDetailDTO productDetailDTO)
        {
            Dictionary<string, string> exceptions = new Dictionary<string, string>();

            var productDetail = await _productDetailService.GetProductDetailById(productDetailDTO.ProductDetailId);

            if (productDetail != null)
            {
                if (exceptions.Count == 0)
                {
                    productDetail.ProductId = productDetailDTO.ProductId;
                    productDetail.Description = productDetailDTO.Description;
                    productDetail.Rating = productDetailDTO.Rating;
                    productDetail.Stock = productDetailDTO.Stock;
                    productDetail.Weight = productDetailDTO.Weight;
                    productDetail.Warranty = productDetailDTO.Warranty;
                    productDetail.ChangedOn = DateTime.Now;
                }

                await _productDetailService.UpdateProductDetail(productDetail);
                return ProductDetailOutputDTO.MapToEntity(productDetail);
            }
            else
            {
                throw new CustomException(exceptions);
            }
        }

        public async Task<ProductDetailOutputDTO> DeleteProductDetail(int productDetailId)
        {
            Dictionary<string, string> exceptions = new Dictionary<string, string>();

            var productDetail = await _productDetailService.GetProductDetailById(productDetailId);

            if (productDetail == null)
            {
                exceptions.Add("no Product", "product with this ID doesn't exist");

                throw new CustomException(exceptions);
            }
            else
            {
                await _productDetailService.DeleteProductDetail(productDetail);

                return ProductDetailOutputDTO.MapToEntity(productDetail);
            }
        }

        public async Task<ProductDetailOutputDTO> GetProductDetailById(int productDetailId)
        {
            Dictionary<string, string> exceptions = new Dictionary<string, string>();

            var productDetail = await _productDetailService.GetProductDetailById(productDetailId);

            if (productDetail == null)
            {
                exceptions.Add("no Product", "product with this ID doesn't exist");

                throw new CustomException(exceptions);
            }
            else
            {
                return ProductDetailOutputDTO.MapToEntity(productDetail);
            }
        }

        public async Task<ProductDetailOutputDTO> GetProductDetailByProductId(int productId)
        {
            Dictionary<string, string> exceptions = new Dictionary<string, string>();

            var productDetail = await _productDetailService.GetProductDetailByProductId(productId);

            if (productDetail == null)
            {
                exceptions.Add("no Product", "product with this ID doesn't exist");

                throw new CustomException(exceptions);
            }
            else
            {
                return ProductDetailOutputDTO.MapToEntity(productDetail);
            }
        }
    }
}
