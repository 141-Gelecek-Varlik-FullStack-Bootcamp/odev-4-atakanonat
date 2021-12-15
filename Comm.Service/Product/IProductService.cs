using System.Collections.Generic;
using Comm.Model;

namespace Comm.Service.Product
{
    public interface IProductService
    {
        Common<Model.Product.Product> Get(int id);
        List<Common<Model.Product.Product>> GetProducts(Model.Pagination.PaginationParameters pagination);
        Common<Model.Product.Product> Add(Model.Product.Product newProduct);
        bool Update();
        bool Delete();
    }
}