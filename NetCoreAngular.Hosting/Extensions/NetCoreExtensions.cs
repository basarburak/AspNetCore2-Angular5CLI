using System;
using System.IO;
using System.Runtime.InteropServices;
using Backend.Api.Contracts.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreStack.Proxy;

namespace NetCoreAngular.Hosting.Extensions
{
    public static class NetCoreExtensions
    {
        private static string startChromeWindows = "start chrome http://localhost:";
        private static string startChromeMac = @"/Applications/Google\ Chrome.app/Contents/MacOS/Google\ Chrome --app=";
        public static void UseAngular(this IApplicationBuilder app)
        {
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
        }

        public static void UseMultiplateApplication(this IApplicationBuilder app, IConfiguration configuration)
        {
            //Api ve Angular CLI uygulamalarını ayağa kaldırmak için.
            RunApplication(app, @"..\Backend\Backend.Api", CommandLine.DotnetRun);
            RunApplication(app, @"..\NetCoreAngular.Client", CommandLine.NpmStart);

            //Browserda önizlemek için kullanacağız.
            StartBrowser(app, new string[]{
                "5000/",
                "5050/",
                "4200/"
            });
        }

        public static void AddNetCoreStackProxy(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddNetCoreProxy(configuration, options =>
             {
                 options.Register<IProductApi>();
             });
        }

        private static void StartBrowser(IApplicationBuilder app, string[] port)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                foreach (var item in port)
                {
                    app.Shell(startChromeWindows + item);
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                foreach (var item in port)
                {
                    app.Shell(startChromeMac + "'" + item + "'");
                }
            }
        }
        private enum CommandLine
        {
            DotnetRun = 1,
            NpmStart = 2
        }

        private static void RunApplication(IApplicationBuilder app, string path, CommandLine commandLine)
        {
            string pathFull = "cd " + path + " && ";

            if (commandLine == CommandLine.DotnetRun)
            {
                app.Shell(pathFull + "dotnet run");
            }
            else if (commandLine == CommandLine.NpmStart)
            {
                app.Shell(pathFull + "npm start");
            }
        }
    }
}