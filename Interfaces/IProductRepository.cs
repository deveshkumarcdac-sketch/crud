using ProductApi.Models;

namespace ProductApi.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task<int> AddProduct(Product product);
        Task<int> UpdateProduct(Product product, int id);
        Task <int>DeleteProduct(int id);
    }
}
