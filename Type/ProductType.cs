using GraphQL.Types;
using GraphQLApplication.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLApplication.Type
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            //Expose
            Field(p => p.Id);
            Field(p => p.Name);
            Field(p => p.Price);
        }


    }
}
