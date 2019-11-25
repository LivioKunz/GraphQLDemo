using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQLTests;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<ProductSchema>();
            services.AddScoped<ShopData>();


            //services.AddSingleton<ShopMutation>();
            services.AddSingleton<ShopQuery>();

            services.AddSingleton<ProductType>();
            services.AddSingleton<ProductCatetoryEnumType>();
            //services.AddSingleton<ProductInputType>();
                
            services.AddGraphQL(x =>
                {
                    x.EnableMetrics = true;
                    x.ExposeExceptions = true;
                })
                .AddGraphTypes(ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // add http for Schema at default url /graphql
            app.UseGraphQL<ProductSchema>();

            // use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

        }
    }
}
