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

            }

            app.UseAngular();

            app.UseMultiplateApplication();

            app.UseMvc();

            app.UseStaticFiles();
        }
    }
}
