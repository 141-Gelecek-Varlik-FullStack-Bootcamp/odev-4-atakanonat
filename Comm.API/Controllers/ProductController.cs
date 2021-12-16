using System;
using System.Collections.Generic;
using Comm.API.Infrastructure;
using Comm.Model;
using Comm.Model.Pagination;
using Comm.Service.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;

namespace Comm.API.Controllers
{
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
        public IActionResult ProductList([FromQuery] PaginationParameters pagination
        , [FromQuery] string sortBy, [FromQuery] string searchString)
        {
            var result = productService.GetProducts(pagination, sortBy, searchString);
            // Send returned product data to view page.
            ViewBag.Products = result;
            if (pagination.PageNumber > result.TotalPages)
            {
                return RedirectToAction("", new { pageNumber = result.TotalPages, pageSize = pagination.PageSize });
            }
            else if (pagination.PageSize > result.TotalEntity)
            {
                return RedirectToAction("", new { pageNumber = 1, pageSize = result.TotalEntity });
            }
            return View();
        }

        [HttpGet("/[controller]/{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = productService.Get(id);
            ViewBag.Product = result.Entity;
            return View();
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

        [HttpGet("/[controller]/{id}/update")]
        public IActionResult ProductUpdateForm(int id)
        {
            var result = productService.Get(id);
            ViewBag.Product = result;
            return View();
        }

        [HttpPost("/[controller]/{id}")]
        // [ServiceFilter(typeof(LoginFilter))]
        public IActionResult UpdateProduct([FromForm] Model.Product.Product updatedProduct, int id)
        {
            updatedProduct.Id = id;
            productService.Update(updatedProduct);
            return RedirectToAction(id.ToString(), "Product");
        }
    }
}