using Warehouse.API.DataService.IDataService;
using Warehouse.API.DataService.Models;
using Warehouse.API.Manager.DTO;
using Warehouse.API.Manager.Exceptions;

namespace Warehouse.API.Manager.Manager
{
    public class ProductManager
    {
        private readonly IProductService _productService;

        public ProductManager(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<ProductOutputDTO>> GetAllProducts()
        {
            Dictionary<string,string> exceptions = new Dictionary<string,string>();

            var product = await _productService.GetAllProducts();

            if (product == null)
            {
                exceptions.Add("no products", "No products");

                throw new CustomException(exceptions);
            }
            else
            {
                var res = product.Select(x => ProductOutputDTO.MapToEntity(x)).ToList();

                return res;
            }
        }

        public async Task<ProductOutputDTO> AddProduct(ProductDTO productDTO)
        {
            Dictionary<string, string> exceptions = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(productDTO.Title))
                exceptions.Add("title missing", "Title can't be empty");

            if (string.IsNullOrWhiteSpace(productDTO.Category))
                exceptions.Add("category missing", "Category can't be empty");

            if (productDTO.Price < 0)
                exceptions.Add("price ", "Price can't be negative");

            if (exceptions.Count == 0)
            {
                var product = new Product
                {
                    Title = productDTO.Title,
                    Category = productDTO.Category,
                    Price = productDTO.Price,
                    Brand = productDTO.Brand,
                    CreatedOn = DateTime.Now,
                };

                await _productService.AddProduct(product);
                return ProductOutputDTO.MapToEntity(product);
            }
            else
            {
                throw new CustomException(exceptions);
            }
        }

        public async Task<ProductOutputDTO> UpdateProduct(ProductDTO productDTO)
        {
            Dictionary<string, string> exceptions = new Dictionary<string, string>();

            var product = await _productService.GetProductById(productDTO.ProductId);

            if (product != null)
            {
                if(product.Title != productDTO.Title)
                {
                    if (string.IsNullOrWhiteSpace(productDTO.Title))
                        exceptions.Add("Title missing", "Title can;t be empty");
                }

                if(product.Category != productDTO.Category)
                {
                    if (string.IsNullOrWhiteSpace(productDTO.Category))
                        exceptions.Add("category missing", "Category can't be empty");
                }

                if(product.Price != productDTO.Price)
                {
                    if (productDTO.Price < 0)
                        exceptions.Add("price ", "Price can't be negative");
                }

                if (exceptions.Count == 0)
                {
                    product.Title = productDTO.Title;
                    product.Category = productDTO.Category;
                    product.Price = productDTO.Price;
                    product.Brand = productDTO.Brand;
                    product.ChangedOn = DateTime.Now;
                }

                await _productService.UpdateProduct(product);
                return ProductOutputDTO.MapToEntity(product);
            }
            else
            {
                exceptions.Add("Invalid ProductId", "Product with this ID doesn't exist");

                throw new CustomException(exceptions);
            }
        }

        public async Task<ProductOutputDTO> DeleteProduct(int productId)
        {
            Dictionary<string, string> exceptions = new Dictionary<string, string>();

            var product = await _productService.GetProductById(productId);

            if (product == null)
            {
                exceptions.Add("no Product", "product with this ID doesn't exist");

                throw new CustomException(exceptions);
            }
            else
            {
                await _productService.DeleteProduct(product);

                return ProductOutputDTO.MapToEntity(product);
            }
        }

        public async Task<ProductOutputDTO> GetProductById(int productId)
        {
            Dictionary<string, string> exceptions = new Dictionary<string, string>();

            var product = await _productService.GetProductById(productId);

            if (product == null)
            {
                exceptions.Add("no Product", "product with this ID doesn't exist");

                throw new CustomException(exceptions);
            }
            else
            {
                return ProductOutputDTO.MapToEntity(product);
            }
        }

        public async Task<List<ProductOutputDTO>> GetFilteredProducts(string search)
        {
            var products = await _productService.FilteredProduct(search);

            return products.Select(x => ProductOutputDTO.MapToEntity(x)).ToList();
        }
    }
}
