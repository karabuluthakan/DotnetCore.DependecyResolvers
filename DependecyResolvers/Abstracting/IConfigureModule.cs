using Microsoft.AspNetCore.Builder;

namespace DotnetCore.DependecyResolvers.DependecyResolvers.Abstracting
{
    public interface IConfigureModule
    {
        int Priority { get; set; }
        void Load(IApplicationBuilder app);
    }
}