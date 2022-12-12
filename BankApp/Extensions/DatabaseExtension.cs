using BankApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BankApp.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContextPool<BankContext>(optionsAction: options =>
            {
                //options.UseSqlite("Data Source=BankAppDatabase.sqlite3", sqliteOptionsAction: sqlOptions =>
                //{
                //    //sqlOptions.MigrationsAssembly("BankApp.Data");
                //});
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("BankApp.Data");
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    sqlOptions.CommandTimeout((int)TimeSpan.FromSeconds(30).TotalSeconds);
                });
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
                options.LogTo(message => Debug.Write(message));
            });
        }
    }
}
