using GraphQL;
using GraphQL.Types;
using GraphQLApplication.Interfaces;
using GraphQLApplication.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLApplication.Query
{
    public class ProductQuery : ObjectGraphType
    {

        public ProductQuery(IProduct productService)
        {
            //Use lambda expression
            Field<ListGraphType<ProductType>>("products", resolve: context => { return productService.GetAllProducts(); });

            Field<ProductType>("products",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    return productService.GetProductById(context.GetArgument<int>("id"));
                });
        }
    }
}
