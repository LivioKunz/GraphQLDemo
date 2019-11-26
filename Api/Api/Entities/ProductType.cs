using GraphQL.Types;

namespace GraphQLTests
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ShopData shopData)
        {
            Name = "Product";

            Field(x => x.Id);            
            Field(x => x.Name).Description("The name of the product");
            Field(x => x.Price).Description("The price of the product");
            Field(x => x.PhotoFileName);
            Field(x => x.Description);
            Field<ProductCatetoryEnumType>("Category");

            Field<ListGraphType<ProductType>>("SimilarProducts", "You may also be interested in",
                resolve: context => shopData.GetProducts(context.Source.SimilarProducts));

        }
    }
}