using GraphQL.Types;
using GraphQLTests;

namespace Api.Entities
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ShopDataRepository shopDataRepository)
        {
            Name = "Product";

            Field(x => x.Id);            
            Field(x => x.Name).Description("The name of the product");
            Field(x => x.Price).Description("The price of the product");
            Field(x => x.PhotoFileName);
            Field(x => x.Description);
            Field<ProductCatetoryEnumType>("Category");

            Field<ListGraphType<ProductType>>("SimilarProducts", "You may also be interested in",
                resolve: context => shopDataRepository.GetProducts(context.Source.SimilarProducts));

        }
    }
}