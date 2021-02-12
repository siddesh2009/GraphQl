using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQlV1.GraphQl.Schema;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sco.Business.Contract;
using Sco.Business.Logic.UserBusinessLogic;
using Sco.Data.Contract;
using Sco.Data.Logic;

namespace GraphQlV1
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
            //services.AddDbContext<ScoDbContext>(options => {
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //});

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddDbContext<ScoDbContext>(
                optionsAction: options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
                contextLifetime: ServiceLifetime.Singleton);

            services.AddScoped<IServiceProvider>(c => new FuncServiceProvider(type => c.GetRequiredService(type)));
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;
                //options.ExposeExceptions = true; // false prints message only, true will ToString
                options.UnhandledExceptionDelegate = context =>
                {
                    Console.WriteLine("Error: " + context.OriginalException.Message);
                };
            })
            .AddSystemTextJson()
            .AddNewtonsoftJson()
            .AddWebSockets()
            .AddDataLoader()
            .AddGraphTypes(typeof(UserDetailSchema));
            

            services.AddTransient<IUserBusinessMgr, UserBusinessMgr>();
            services.AddTransient<IUserDataMgr, UserDataMgr>();
            services.AddControllers();

            services.AddCustomGraphQLTypes();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            app.UseWebSockets();
            app.UseGraphQLPlayground();
            
            app.UseGraphQL<UserDetailSchema>();
            app.UseGraphQLWebSockets<UserDetailSchema>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
