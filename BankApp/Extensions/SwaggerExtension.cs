using Microsoft.OpenApi.Models;

namespace BankApp.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                //options.OperationFilter<DefaultValues>();
                //options.OperationFilter<SwaggerDefaultValues>();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Bank API v1",
                    Version = "v1",
                });
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Bank API v2",
                    Version = "v2",
                });

                options.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Name = "Basic",
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic authentication can be used only for AccessToken resource"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,// SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    Scheme = "bearer",
                    In = ParameterLocation.Header,
                    Description = "Provide a token in the form 'Bearer {key}' to access a resource"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Basic"
                            },
                            Scheme = "basic",
                            Name = "Basic",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            //Scheme = "oauth2",
                            //Name = "Bearer",
                            //In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
                options.ResolveConflictingActions(c => c.Last());
            });
        }
    }
}
