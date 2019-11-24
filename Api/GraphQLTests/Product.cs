using System;
using GraphQL;
using GraphQL.Types;

namespace GraphQLTests
{
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
        public int Id { get; set; }

        public int[] SimilarProducts { get; set; }
        public ProductCategory Category { get; set; }
    }

    public enum ProductCategory
    {
        Trousers,
        TShirts,
        Jackets
    }

    public class ProductInputType : ObjectGraphType<Product>
    {
        public ProductInputType()
        {
            Name = "ProductInput";

            Field(x => x.Name);
            Field(x => x.Price);
            Field(x => x.SimilarProducts, true);
        }
    }


}
