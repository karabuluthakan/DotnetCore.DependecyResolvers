using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DotnetCore.DependecyResolvers.Contracts;
using DotnetCore.DependecyResolvers.DependecyResolvers.Abstracting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DotnetCore.DependecyResolvers.DependecyResolvers.ConfigureServices
{
    public class AddSwaggerConfig : IConfigureServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(DefaultConstants.Version,
                    new Info
                    {
                        Title = DefaultConstants.SwaggerTitle,
                        Version = DefaultConstants.Version,
                        Description = DefaultConstants.SwaggerDescription,
                        Contact = new Contact
                        {
                            Name = DefaultConstants.SwaggerContactName,
                            Email = DefaultConstants.SwaggerContactEmail,
                            Url = DefaultConstants.SwaggerContactUrl
                        },
                        License = new License
                        {
                            Name = DefaultConstants.SwaggerLicenceName,
                            Url = DefaultConstants.SwaggerContactUrl
                        },
                        TermsOfService = DefaultConstants.SwaggerTermsOfService
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
                x.AddFluentValidationRules();

                x.EnableAnnotations();

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {DefaultConstants.Bearer, new string[0]}
                };
                x.AddSecurityDefinition(DefaultConstants.Bearer, new ApiKeyScheme
                {
                    Description = DefaultConstants.SwaggerSecurityDescription,
                    Name = DefaultConstants.Authorization,
                    In = DefaultConstants.Header,
                    Type = DefaultConstants.ApiKey
                });
                x.AddSecurityRequirement(security);
            });
        }
    }
}