using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using apiassignment.Contracts;

namespace apiassignment.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepo;

        public ProductsController(IProductsRepository productsRepo)
        {
            _productsRepo = productsRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
            var products = await _productsRepo.GetAll();
            return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var products = await _productsRepo.Get(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Products product)
        {
            try
            {
                var newProduct = await _productsRepo.Post(product);
                return Ok("New Product added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, string name)
        {
            try
            {
                var newProduct = await _productsRepo.Put(id, name);
                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("productmanufacturer/")]
        public async Task<IActionResult> GetProductManufacturer(string manufacturer)
        {
            try
            {
                var productmanufacturer = await _productsRepo.GetProductManufacturer(manufacturer);
                return Ok(productmanufacturer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _productsRepo.Delete(id);
                return Ok("Product deleted");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
