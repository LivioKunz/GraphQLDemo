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
                Name = "Denim White-Shirt",
                Id = 1,
                SimilarProducts = new[] { 4 },
                Category = ProductCategory.TShirts,
                PhotoFileName = "00388030_163952_weiss_flat.550.png",
                Description = "Polo-Shirt aus Piqué"
            };

            _products.Add(_productOne);

            _products.Add(new Product
            {
                Price = new decimal(14.75),
                Name = "Lederjacke Braun",
                Id = 2,
                SimilarProducts = new []{3},
                Category = ProductCategory.Jackets,
                PhotoFileName = "00373614_117836_braun_flat.550.png",
                Description = "Replay, Unser Model misst 187 cm und trägt Grösse M."
            });

            _products.Add(new Product
            {
                Price = new decimal(15.5),
                Name = "Lederjacke Schwarz",
                Id = 3,
                SimilarProducts = new[] { 2 },
                Category = ProductCategory.Jackets,
                PhotoFileName = "lj_schwarz.png",
                Description = "Paul Kehl, Unser Model misst 182 cm und trägt Grösse M."
            });

            _products.Add(new Product
            {
                Price = new decimal(77.70),
                Name = "Drykorn",
                Id = 4,
                SimilarProducts = new[] { 1 },
                Category = ProductCategory.TShirts,
                PhotoFileName = "00280988_163748_gelb_flat.550.png",
                Description = "Della Ciana, Unser Model misst 182 cm und trägt Grösse 50."
            });

            _products.Add(new Product
            {
                Price = new decimal(45.50),
                Name = "Jeans",
                Id = 4,
                SimilarProducts = new[] { 1 },
                Category = ProductCategory.Trousers,
                PhotoFileName = "00380610_148198_dark-denim_flat.550.png",
                Description = "Jeans ANBASS, Dark Denim"
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