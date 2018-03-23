using Microsoft.AspNetCore.Builder;

namespace NetCoreAngular.Hosting.Extensions
{
    public class StartMultiApplication
    {
        public static void Start(IApplicationBuilder app)
        {
            string angularApp = @"cd ..\NetCoreAngular.Client && ng serve";
            string mainApi = @"cd ..\Backend\Backend.Api && dotnet run";
            app.Shell(mainApi);
            app.Shell(angularApp);
        }
    }
}