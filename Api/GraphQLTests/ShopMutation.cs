using GraphQL.Types;

namespace GraphQLTests
{
    public class ShopMutation : ObjectGraphType
    {
        public ShopMutation(ShopData shopData)
        {
            Name = "Mutation";

            Field<ProductType>(
                "createProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>> {Name = "product"}),
                resolve: context =>
                {
                    var product = context.GetArgument<Product>("product");
                    return shopData.AddProduct(product);
                });
        }
    }
}   