using GraphQLApplication.Interfaces;
using GraphQLApplication.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLApplication.Services
{
    public class ProductService : IProduct
    {
        private static List<Product> _products = new List<Product> {
            new Product(){Id=0, Name = "Product_0", Price=0.00},
            new Product(){Id=1, Name = "Product_1", Price=0.01},
            new Product(){Id=2, Name = "Product_2", Price=0.02}
        };

        public Product AddProduct(Product product)
        {
            product.Id = _products.Count();
            _products.Add(product);

            return product;
        }

        public void DeleteProduct(int id)
        {
            _products.RemoveAt(id);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(int id)
        {
            return _products.Find(p => p.Id == id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            _products[id] = product;
            return product;
        }
    }
}
