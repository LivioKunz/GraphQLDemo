using GraphQL.Types;

namespace GraphQLTests
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "ProductInput";

            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("description");
            Field<StringGraphType>("photoFileName");
            Field<DecimalGraphType>("price"); 
        }
    }
}
