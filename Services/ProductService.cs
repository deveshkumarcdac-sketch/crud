using ProductApi.Interfaces;
using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository; //dependency injected
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }
        public async Task<Product>GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }
        public async Task<int> AddProduct(Product product)
        {
            return await _productRepository.AddProduct(product);
        }
        public async Task<int> UpdateProduct(Product product, int id)
        {
            return await _productRepository.UpdateProduct(product, id);
        }
        public async Task<int> DeleteProduct(int id)
        {
            return await _productRepository.DeleteProduct(id);
        }
    }
}
