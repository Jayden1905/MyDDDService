using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyDDDService.Application.Services;

namespace MyDDDService.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController(ProductService productService) : ControllerBase
    {
        private readonly ProductService _productService = productService;

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDto productDto)
        {
            _productService.CreateProduct(productDto.Id, productDto.Name, productDto.Price);
            return Ok(new { message = "Product created successfully" });
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProductByID(id);
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
    }
}

public class ProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
}
