using Api.Entities;
using GraphQL.Types;

namespace Api.GraphQL
{
    public class ShopQuery : ObjectGraphType
    {
        public ShopQuery(ShopDataRepository shopDataRepository)
        {
            Name = "Query";

            Field<ListGraphType<ProductType>>(
               "products",
               resolve: context => shopDataRepository.GetAll());

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    { Name = "id", Description = "Id of the product" }),
                //GraphQL handelt Async call
                resolve: context => shopDataRepository.GetProductAsync(context.GetArgument<int>("id"))
            );           
        }
    }
}