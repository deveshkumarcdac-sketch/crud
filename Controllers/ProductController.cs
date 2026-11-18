using Microsoft.AspNetCore.Mvc;
using ProductApi.Interfaces;
using ProductApi.Models;

namespace ProductApi.Controllers
{
        [ApiController]
        [Route("api/controller")]

        public class ProductController : ControllerBase
        {
            private readonly IProductService _productService;
            public ProductController(IProductService productService)
            {
                _productService = productService;
            }
            [HttpGet]
            public async Task<IActionResult> GetAllProducts()
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetProductById(int id)
            {
                var product = await _productService.GetProductById(id);
                return Ok(product);
            }

            [HttpPost]
            public async Task<IActionResult>AddProduct(Product product)
            {
                var result = await _productService.AddProduct(product);
                return Ok(result);
            }
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateProduct(Product product, int id)
            {
                var result = await _productService.UpdateProduct(product, id);
                return Ok(result);
            }
            [HttpDelete("id")]
            public async Task<IActionResult> DeleteProduct(int id)
            {
                var result = _productService.DeleteProduct(id);
                return Ok("product deleted successfully");
            }
        }
}
