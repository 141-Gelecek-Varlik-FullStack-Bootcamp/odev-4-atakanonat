using System.Collections.Generic;
using Comm.Model;

namespace Comm.Service.Product
{
    public interface IProductService
    {
        Common<Model.Product.Product> Get(int id);
        Common<List<Model.Product.Product>> GetProducts(Model.Pagination.PaginationParameters pagination, string sortBy, string searchString);
        Common<Model.Product.Product> Add(Model.Product.Product newProduct);
        bool Update();
        bool Delete();
    }
}