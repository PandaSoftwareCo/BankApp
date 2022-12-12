using BankApp.Core.Domain.Entities;
using BankApp.Core.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Data.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(i => i.VehicleId);
            builder.Property(i => i.VehicleId).IsRequired().UseIdentityColumn();

            builder.Property(i => i.Make).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Model).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Year).IsRequired();

            builder.HasData(new[]
{
                new Vehicle { VehicleId = 1, Make = "Honda", Model = "Civic", Year = 2018 },
                new Vehicle { VehicleId = 2, Make = "Honda", Model = "Civic", Year = 2022 }
            });
        }
    }
}
