using System.IO;
using Microsoft.AspNetCore.Builder;

namespace NetCoreAngular.Hosting.Extensions
{
    public static class NetCoreExtensions
    {
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

        public static void UseMultiplateApplication(this IApplicationBuilder app)
        {
            string angularApp = @"cd ..\NetCoreAngular.Client && ng serve";
            string mainApi = @"cd ..\Backend\Backend.Api && dotnet run";
            app.Shell(mainApi);
            app.Shell(angularApp);
        }
    }
}