using BankApp.Application.Common.Interfaces;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Repositories;
using BankApp.Identity.Helpers;
using BankApp.Identity.Services;
using BankApp.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;

namespace BankApp.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection(nameof(AuthSettings)));
            builder.Services.AddSingleton<AuthSettings>(sp => sp.GetRequiredService<IOptions<AuthSettings>>().Value);

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddScoped<IValidator<Account>, AccountValidator>();
            builder.Services.AddScoped<IValidator<Balance>, BalanceValidator>();
            builder.Services.AddScoped<IValidator<BankTransaction>, BankTransactionValidator>();
            builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();
            builder.Services.AddScoped<IValidator<Mileage>, MileageValidator>();
            builder.Services.AddScoped<IValidator<Vehicle>, VehicleValidator>();

            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IBalanceRepository, BalanceRepository>();
            builder.Services.AddScoped<IBankTransactionRepository, BankTransactionRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IMileageRepository, MileageRepository>();
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

            builder.Services.AddScoped<IUserService, UserService>();

            var httpRetryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));
            var httpRetryPolicy2 = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30));
            builder.Services.AddSingleton<IAsyncPolicy<HttpResponseMessage>>(httpRetryPolicy);
        }
    }
}
