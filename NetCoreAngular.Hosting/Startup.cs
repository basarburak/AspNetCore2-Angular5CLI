using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Contracts.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCoreAngular.Hosting.Extensions;
using NetCoreStack.Proxy;

namespace NetCoreAngular.Hosting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddNetCoreProxy(Configuration, options =>
        {
            //MAin Api
            options.Register<IProductApi>();
            options.CultureFactory = () =>
      {
          return System.Threading.Thread.CurrentThread.CurrentCulture;
      };
        });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
             //   app.Shell("../Backend/Backend.Api" + "dotnet run");
             
            //  string angularApp = @"cd\..\NetCoreAngular.Client && ng serve";
            //  app.Shell(angularApp);
            }

            string angularApp = @"cd ..\NetCoreAngular.Client && ng serve";
             app.Shell(angularApp);

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404 &&
                    !Path.HasExtension(context.Request.Path.Value) &&
                    !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseMvc();
            app.UseStaticFiles();
        }
    }
}
