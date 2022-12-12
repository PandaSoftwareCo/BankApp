using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Extensions
{
    public static class VersioningExtension
    {
        public static void AddVersioning(this WebApplicationBuilder builder)
        {
            builder.Services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
                //setup.UseApiBehavior = true;
                setup.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new QueryStringApiVersionReader(),
                    new QueryStringApiVersionReader("v"),
                    new HeaderApiVersionReader("v"),
                    new HeaderApiVersionReader("api-version"),
                    new MediaTypeApiVersionReader(),
                    new MediaTypeApiVersionReader("api-version"));
            });
            builder.Services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
