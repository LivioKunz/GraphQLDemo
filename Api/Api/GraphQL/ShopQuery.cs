using Api.Entities;
using GraphQL.Types;

namespace Api.GraphQL
{
    public class ShopQuery : ObjectGraphType
    {
        public ShopQuery(ShopData shopData)
        {
            Name = "Query";

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    { Name = "id", Description = "Id of the product" }),
                resolve: context => shopData.GetProductAsync(context.GetArgument<int>("id"))
            );

            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => shopData.GetAll());
        }
    }
}