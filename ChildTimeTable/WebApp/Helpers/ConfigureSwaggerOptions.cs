using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Options;

/*namespace WebApp.Helpers
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>{
        readonly IApiVersionDescriptionProvider _provider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) =>
            _provider = provider;

        public void Configure( SwaggerGenOptions options ){
            foreach ( var description in _provider.ApiVersionDescriptions ) {
                options.SwaggerDoc(
                    description.GroupName,
                    new OpenApiInfo(){
                        Title = $"Owners and Animals API {description.ApiVersion}",
                        Version = description.ApiVersion.ToString()
                    });
            }
            
            // include xml comments (enable creation in csproj file)
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);

        }
    }
}*/