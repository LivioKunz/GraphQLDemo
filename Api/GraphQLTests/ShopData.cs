using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTests
{
    public class ShopData
    {
        private readonly List<Product> _products = new List<Product>();
        private Product _productOne;

        public ShopData()
        {
            _productOne = new Product
            {
                Price = new decimal(12.5),
                Name = "Pizza",
                Id = 1,
                SimilarProducts = new [] {2},
                Category = ProductCategory.TShirts
            };

            _products.Add(_productOne);

            _products.Add(new Product
            {
                Price = new decimal(15.5),
                Name = "Lasagne",
                Id = 2,
                SimilarProducts = new []{1},
                Category = ProductCategory.Jackets
            });
        }

        public Product GetProduct(int id)
        {
            if (id <= 0)
                return null;

            return _products.Single(x => x.Id == id);
        }

        public Task<Product> GetProductAsync(int id)
        {
            return Task.FromResult(_products.SingleOrDefault(x => x.Id == id));
        }

        public Product AddProduct(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return product;
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetProducts(int[] sourceSimilarProducts)
        {
            return _products.Where(x => sourceSimilarProducts.Contains(x.Id)).ToList();
        }
    }
}