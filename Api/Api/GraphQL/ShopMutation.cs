using Api.Entities;
using GraphQL.Types;
using GraphQLTests;

namespace Api.GraphQL
{
    public class ShopMutation : ObjectGraphType
    {
        public ShopMutation(ShopDataRepository shopData)
        {
            Field<ProductType>(
                "createProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>> {Name = "productInput"}),
                resolve: context =>
                {
                    var product = context.GetArgument<Product>("productInput");
                    return shopData.AddProduct(product);
                });
        }
    }
}   