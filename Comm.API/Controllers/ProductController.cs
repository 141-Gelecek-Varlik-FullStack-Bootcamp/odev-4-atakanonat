using System.Collections.Generic;
using System.Text.Json;
using Comm.API.Infrastructure;
using Comm.Model;
using Comm.Model.Pagination;
using Comm.Service.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Comm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IDistributedCache _distributedCache;
        public ProductController(IProductService productService, IDistributedCache distributedCache)
        {
            _productService = productService;
            _distributedCache = distributedCache;
        }

        [HttpGet("/api/[controller]")]
        public IActionResult ProductList([FromQuery] PaginationParameters pagination
        , [FromQuery] string sortBy, [FromQuery] string searchString)
        {
            var result = JsonSerializer.Serialize(_productService.GetProducts(pagination, sortBy, searchString));
            return Ok(result);
        }

        [HttpGet("/api/[controller]/{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = JsonSerializer.Serialize(_productService.Get(id).Entity);
            return Ok(result);
        }

        [HttpPost("/api/[controller]")]
        [ServiceFilter(typeof(LoginFilter))]
        public Model.Product.Product AddProduct([FromForm] Model.Product.Product newProduct)
        {
            return _productService.Add(newProduct).Entity;
        }

        [HttpPost("/api/[controller]/{id}")]
        // [ServiceFilter(typeof(LoginFilter))]
        public Common<Model.Product.Product> UpdateProduct([FromForm] Model.Product.Product updatedProduct)
        {
            return _productService.Update(updatedProduct);
        }
    }
}