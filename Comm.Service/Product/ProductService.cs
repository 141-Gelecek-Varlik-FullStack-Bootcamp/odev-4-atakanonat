using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Comm.DB.Entities;
using Comm.Model;
using Comm.Model.Pagination;

namespace Comm.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        public ProductService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        public Common<Model.Product.Product> Get(int id)
        {
            var result = new Common<Model.Product.Product>() { IsSuccess = false };
            if (id < 0) return result;
            using (var srv = new CommContext())
            {
                var dbProduct = srv.Product.SingleOrDefault(p => p.Id == id);
                if (dbProduct is not null)
                {
                    var mappedProduct = mapper.Map<Model.Product.Product>(dbProduct);
                    result.Entity = mappedProduct;
                    result.IsSuccess = true;
                }
            }

            return result;
        }

        public List<Common<Model.Product.Product>> GetProducts(PaginationParameters pagination, string sortBy)
        {
            var result = new List<Common<Model.Product.Product>>();
            using (var srv = new CommContext())
            {
                var dbProducts = from p in srv.Product select p;
                switch (sortBy)
                {
                    case "name_desc":
                        dbProducts = dbProducts.OrderByDescending(p => p.Name);
                        break;
                    case "Price":
                        dbProducts = dbProducts.OrderBy(p => p.Price);
                        break;
                    case "price_desc":
                        dbProducts = dbProducts.OrderByDescending(p => p.Price);
                        break;
                    case "Idate":
                        dbProducts = dbProducts.OrderBy(p => p.Idate);
                        break;
                    case "idate_desc":
                        dbProducts = dbProducts.OrderByDescending(p => p.Idate);
                        break;
                    default:
                        dbProducts = dbProducts.OrderBy(p => p.Name);
                        break;
                }
                var Products =
                dbProducts
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                    .Take(pagination.PageSize)
                    .ToList();
                foreach (var product in Products)
                {
                    var commonMappedModel = new Common<Model.Product.Product>();
                    var mappedProduct = mapper.Map<Model.Product.Product>(product);
                    commonMappedModel.Entity = mappedProduct;
                    commonMappedModel.IsSuccess = true;
                    result.Add(commonMappedModel);
                }
            }

            return result;
        }
        public Common<Model.Product.Product> Add(Model.Product.Product newProduct)
        {
            var result = new Common<Model.Product.Product>() { IsSuccess = false };
            var mappedProduct = mapper.Map<DB.Entities.Product>(newProduct);
            using (var srv = new CommContext())
            {
                srv.Database.BeginTransaction();
                mappedProduct.Idate = System.DateTime.Now;
                srv.Product.Add(mappedProduct);
                srv.SaveChanges();
                result.Entity = mapper.Map<Model.Product.Product>(mappedProduct);
                result.IsSuccess = true;
                srv.Database.CommitTransaction();
            }

            return result;
        }

        public bool Update()
        {
            var result = false;
            return result;
        }
        public bool Delete()
        {
            var result = false;
            return result;
        }

    }
}