using GraphQLApplication.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLApplication.Interfaces
{
    public interface IProduct
    {
        List<Product> GetAllProducts();
        Product AddProduct(Product product);
        Product GetProductById(int id);
        Product UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
    }
}
