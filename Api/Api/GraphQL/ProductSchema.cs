using GraphQL;
using GraphQL.Types;

namespace GraphQLTests
{
    public class ProductSchema : Schema
    {
        public ProductSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ShopQuery>();
            Mutation = resolver.Resolve<ShopMutation>();
        }
    }
}