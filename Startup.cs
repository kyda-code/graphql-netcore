using GraphQL.SystemTextJson;
using GraphQL.Types;
using GraphQL.MicrosoftDI;
using GraphQLApplication.Interfaces;
using GraphQLApplication.Query;
using GraphQLApplication.Schema;
using GraphQLApplication.Services;
using GraphQLApplication.Type;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using GraphQL.Instrumentation;

namespace GraphQLApplication
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
            //services.AddControllers();

            //DI for ProductsController
            services.AddTransient<IProduct, ProductService>();

            //Inject all GraphQL Schemas inn ProductSchema
            //services.AddSingleton<ISchema, ProductSchema>();

            // add execution components
            services.AddGraphQL()
                .AddSystemTextJson()
                .AddSchema<ProductSchema>()
                .AddGraphTypes(typeof(ProductQuery).Assembly);

            //Configure GraphQL Server
            services.AddSingleton<ProductType>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQLPlayground();
            app.UseGraphQLGraphiQL();
            app.UseGraphQLAltair();
            app.UseGraphQLVoyager();
        }
    }
}
