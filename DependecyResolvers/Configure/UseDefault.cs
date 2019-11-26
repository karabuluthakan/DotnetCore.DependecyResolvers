using DotnetCore.DependecyResolvers.DependecyResolvers.Abstracting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DotnetCore.DependecyResolvers.DependecyResolvers.Configure
{
    public class UseDefault : IConfigureModule
    {
        public int Priority { get; set; } = 0;
        public void Load(IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetService<IWebHostEnvironment>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}