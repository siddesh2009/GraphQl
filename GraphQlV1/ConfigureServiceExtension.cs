using GraphQlV1.GraphQl.Schema;
using GraphQlV1.GraphQl.Types;
using GraphQlV1.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlV1
{
    public static class ConfigureServiceExtension
    {
        public static void AddCustomGraphQLTypes(this IServiceCollection services) 
        {
            services.AddSingleton<UserDetailType>();
            services.AddSingleton<UserDetailQuery>();
            services.AddSingleton<UserDetailSchema>();
        }
    }
}
