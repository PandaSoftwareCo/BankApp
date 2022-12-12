using BankApp.Data.Contexts;
using BankApp.Data.HealthChecks;
using BankApp.Data.Seed;
using BankApp.Extensions;
using BankApp.Identity.Helpers;
using BankApp.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using StackExchange.Redis;
using System.Reflection;
using System.Text.Json.Serialization;
using VueCliMiddleware;

namespace BankApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Configuration.AddEnvironmentVariables(prefix: "BankApp_");
            builder.Configuration.AddUserSecrets(typeof(Program).Assembly);

            builder.AddLogging();

            builder.Services.AddCors();

            builder.Services.AddHttpClient().AddHttpLogging(options =>
            {
                options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
            });

            builder.AddDatabase();

            // NOTE: PRODUCTION Ensure this is the same path that is specified in your webpack output
            builder.Services.AddSpaStaticFiles(opt => opt.RootPath = "ClientApp/dist");

            builder.Services.AddControllers();

            builder.AddVersioning();

            builder.AddSwagger();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.Configure<JsonOptions>(options =>
            {
                //Microsoft.AspNetCore.Mvc
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
            });

            builder.ConfigureServices();

            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration["ConnectionStrings:RedisConnection"];
                options.InstanceName = "BankApp";
                //options.ConfigurationOptions = new ConfigurationOptions
                //{
                //    ConnectTimeout = 5000,
                //    ConnectRetry = 5,
                //    ReconnectRetryPolicy = new ExponentialRetry(options.ConfigurationOptions.ConnectTimeout / 2)// LinearRetry(2000)
                //};
            });

            // Registers required services for health checks
            builder.Services.AddHealthChecks()
                // Add a health check for a SQL Server database
                .AddCheck(
                    "BankDB-check",
                    new SqlConnectionHealthCheck(builder.Configuration["ConnectionStrings:DefaultConnection"]),
                    HealthStatus.Unhealthy,
                    new string[] { "bankdb" });

            var app = builder.Build();

            app.UseSerilogRequestLogging();

            app.UseExceptionMiddleware();
            app.UseJwtMiddleware();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    IApiVersionDescriptionProvider apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
            }

            app.UseHttpsRedirection();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            // NOTE: PRODUCTION uses webpack static files
            app.UseSpaStaticFiles();

            app.UseAuthorization();

            app.MapControllers();

            // NOTE: VueCliProxy is meant for developement and hot module reload
            // NOTE: SSR has not been tested
            // Production systems should only need the UseSpaStaticFiles() (above)
            // You could wrap this proxy in either
            // if (System.Diagnostics.Debugger.IsAttached)
            // or a preprocessor such as #if DEBUG
            app.MapToVueCliProxy(
                "{*path}",
                new SpaOptions { SourcePath = "ClientApp" },
                npmScript: (System.Diagnostics.Debugger.IsAttached) ? "serve" : null,
                regex: "Compiled successfully",
                forceKill: true
                );

            app.MapHealthChecks("/health");

            SeedData.EnsurePopulated(app).Wait();

            app.Run();
        }
    }
}