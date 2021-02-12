using GraphQlV1.Queries;
using Sco.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlV1.GraphQl.Schema
{
    public class UserDetailSchema: GraphQL.Types.Schema
    {
        public UserDetailSchema(IServiceProvider services) : base(services)
        {
            //Services = services;
            Query = (UserDetailQuery)services.GetService(typeof(UserDetailQuery));
        }
    }
}
