using DotnetCore.DependecyResolvers.DependecyResolvers.Abstracting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetCore.DependecyResolvers
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ServicesInstallerAssembly();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.ConfigurationsInstallerAssembly();
        }
    }
}