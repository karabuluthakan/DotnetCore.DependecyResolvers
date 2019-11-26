using Microsoft.Extensions.DependencyInjection;

namespace DotnetCore.DependecyResolvers.DependecyResolvers.Abstracting
{
    public interface IConfigureServiceModule
    {
        void Load(IServiceCollection services);
    }
}