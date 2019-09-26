using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Environment.Shell;
using OrchardCore.Modules;

namespace Module2
{
    public class Startup : StartupBase
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public override void ConfigureServices(IServiceCollection services)
        {

        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            builder.Map("/hello", branch =>
                branch.Run(context => context.Response.WriteAsync("Hello World"))
            );

            builder.Map("/info", branch =>
            {
                branch.Run(context =>
                {
                    var shellSettings = context.RequestServices.GetRequiredService<ShellSettings>();
                    return context.Response.WriteAsync(
                        $"Request from tenant: {shellSettings.Name}" + Environment.NewLine +
                        $"RequestUrlHost: {shellSettings.RequestUrlHost}" + Environment.NewLine +
                        $"RequestUrlPrefix: {shellSettings.RequestUrlPrefix}" + Environment.NewLine
                    );
                });
            });
        }

       
    }
}
