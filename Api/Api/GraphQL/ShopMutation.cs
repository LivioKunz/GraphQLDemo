﻿using GraphQL.Types;

namespace GraphQLTests
{
    public class ShopMutation : ObjectGraphType
    {
        public ShopMutation(ShopData shopData)
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