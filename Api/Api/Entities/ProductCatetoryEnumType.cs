using Api.Entities;
using GraphQL.Types;

namespace GraphQLTests
{
    public class ProductCatetoryEnumType : EnumerationGraphType<ProductCategory>
    {
        public ProductCatetoryEnumType()
        {
            Name = "ProductCategory";
            Description = "The category of product (Trousers, Jackets etc..)";
        }
    }
}