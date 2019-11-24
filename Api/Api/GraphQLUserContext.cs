using System.Security.Claims;

namespace Api
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}