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
            string angularApp = @"cd ..\NetCoreAngular.Client && npm start";
            string mainApi = @"cd ..\Backend\Backend.Api && dotnet run";
            app.Shell(mainApi);
            app.Shell(angularApp);
            //Browserda önizlemek için bunu kullanıcaz.
            StartBrowser(app);
        }

        public static void StartBrowser(IApplicationBuilder app)
        {
            app.Shell("start chrome http://localhost:5000/");
            app.Shell("start chrome http://localhost:5050/");
            app.Shell("start chrome http://localhost:4200/");
        }
    }
}