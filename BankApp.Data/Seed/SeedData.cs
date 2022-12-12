using BankApp.Application.Common.Interfaces;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Data.Seed
{
    public static class SeedData
    {
        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            IServiceScope scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BankContext>();
            if ((await context.Database.GetPendingMigrationsAsync()).Any())
            {
                await context.Database.MigrateAsync();
            }

            //if (!context.Accounts.Any())
            //{
            //    var accountString = await File.ReadAllTextAsync("accounts.json");
            //    var accounts = System.Text.Json.JsonSerializer.Deserialize<Account[]>(accountString);
            //}

            if (!context.Users.Any())
            {
                var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                var user = new User
                {
                    FirstName = "James",
                    LastName = "Bond",
                    UserName = "007",
                    Password = "test",
                    Role = "User"
                };
                userService.AddUser(user, "test");
            }
        }
    }
}
