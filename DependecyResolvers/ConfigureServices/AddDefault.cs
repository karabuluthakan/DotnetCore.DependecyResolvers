using DotnetCore.DependecyResolvers.DependecyResolvers.Abstracting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetCore.DependecyResolvers.DependecyResolvers.ConfigureServices
{
    public class AddDefault : IConfigureServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddControllers();

            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
        }
    }
}