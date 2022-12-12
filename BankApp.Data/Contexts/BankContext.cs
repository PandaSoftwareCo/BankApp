using BankApp.Application.Common.Interfaces;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Data.Contexts
{
    public class BankContext : DbContext, IUnitOfWork
    {
        public DbSet<BankTransaction> BankTransactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Mileage> Mileages { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }

        //public BankContext()
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BankAppVue;Integrated Security=True");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Account>(new AccountConfiguration());
            modelBuilder.ApplyConfiguration<Balance>(new BalanceConfiguration());
            modelBuilder.ApplyConfiguration<BankTransaction>(new BankTransactionConfiguration());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            modelBuilder.ApplyConfiguration<Mileage>(new MileageConfiguration());
            modelBuilder.ApplyConfiguration<Vehicle>(new VehicleConfiguration());
        }
    }
}
