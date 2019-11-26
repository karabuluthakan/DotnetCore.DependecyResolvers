using DotnetCore.DependecyResolvers.DependecyResolvers.Abstracting;
using DotnetCore.DependecyResolvers.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetCore.DependecyResolvers.DependecyResolvers.Configure
{
    public class UseSwaggerConfig : IConfigureModule
    {
        public int Priority { get; set; } = 1;

        public void Load(IApplicationBuilder app)
        {
            var swagger = new SwaggerOptions();
            var configuration = app.ApplicationServices.GetService<IConfiguration>();
            configuration.GetSection(nameof(SwaggerOptions)).Bind(swagger);
            app.UseSwagger(opt => { opt.RouteTemplate = swagger.JsonRoute; });
            app.UseSwaggerUI(opt => { opt.SwaggerEndpoint(swagger.UiEndpoint, swagger.Description); });
        }
    }
}