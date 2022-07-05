using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FakeStoreAPIProducts
{
    public class ConfigSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "FakeStoreAPI products fetch with versioning",
                Version = description.ApiVersion.ToString(),
                Description = "This is an API versioning control exercise",
                Contact = new OpenApiContact()
                {
                    Email = "valtsvilcans.dev@gmail.com",
                    Name = "Valts"
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "This version is deprecated";
            }

            return info;
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        public void Configure(SwaggerGenOptions options)
        {
            Configure(options);
        }
    }
}
