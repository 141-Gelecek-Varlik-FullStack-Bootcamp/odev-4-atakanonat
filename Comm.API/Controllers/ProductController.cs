using System;
using System.Collections.Generic;
using Comm.API.Infrastructure;
using Comm.Model;
using Comm.Model.Pagination;
using Comm.Service.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Comm.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMemoryCache memoryCache;
        public ProductController(IProductService _productService, IMemoryCache _memoryCache)
        {
            productService = _productService;
            memoryCache = _memoryCache;
        }

        [HttpGet("/[controller]")]
        public List<Common<Model.Product.Product>> ProductList([FromQuery] PaginationParameters pagination)
        {
            var result = productService.GetProducts(pagination);
            return result;
        }

        [HttpGet("/[controller]/{id}")]
        public Common<Model.Product.Product> GetProduct(int id)
        {
            var result = productService.Get(id);
            return result;
        }

        [HttpGet("/[controller]/add")]
        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult ProductAddForm()
        {
            return View();
        }

        [HttpPost("/[controller]/add")]
        [ServiceFilter(typeof(LoginFilter))]
        public Common<Model.Product.Product> AddProduct([FromForm] Model.Product.Product newProduct)
        {
            var result = productService.Add(newProduct);
            return result;
        }
    }
}