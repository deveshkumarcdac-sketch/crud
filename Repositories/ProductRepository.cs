using Dapper;
using Microsoft.Data.SqlClient;
using ProductApi.Interfaces;
using ProductApi.Interfaces;
using ProductApi.Models;

namespace ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            string query = "select *from Products";
            return await connection.QueryAsync<Product>(query);
        }
        public async Task<Product?>GetProductById(int id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            string query = "select *from Products where Id=@Id";
            return await connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
        }
        public async Task<int> AddProduct(Product product)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            string query = @"insert into Products(Name, Price, Quantity) values(@Name, @Price, @Quantity)";
            return await connection.ExecuteAsync(query, new {Name=product.Name,Price=product.Price, Quantity=product.Quantity});
        }
        public async Task<int> UpdateProduct(Product product, int id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            string query = @"Update Products set Name=@Name, Price=@Price, Quantity=@Quantity where Id=@Id";
            return await connection.ExecuteAsync(query, new {Id = id, product.Name, product.Price, product.Quantity});
        }
        public async Task<int>DeleteProduct(int id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            string query = "delete from Products where Id = @Id";
            return await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
