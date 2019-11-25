using System.Collections.Generic;

namespace Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductModel> SimilarProducts { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    
        public ProductCategory Category { get; set; }

        public string PhotoFileName { get; set; }
    }
}