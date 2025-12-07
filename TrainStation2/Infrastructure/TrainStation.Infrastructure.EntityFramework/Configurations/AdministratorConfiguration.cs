using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainStation.ValueObjects.Validators;
using TrainStation.Domain.Entities;
using TrainStation.ValueObjects;
namespace TrainStation.Infrastructure.EntityFramework.Configurations
{
    public class AdministratorCongiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.AdministratorFirstName)
                .IsRequired()
                .HasConversion(administratorFirstName => administratorFirstName.Value, str => new FirstName(str))
                .HasMaxLength(FirstNameValidator.MAX_LENGTH);
            builder.Property(x => x.AdministratorLastName)
                .IsRequired()
                .HasConversion(administratorLastName => administratorLastName.Value, str => new LastName(str))
                .HasMaxLength(LastNameValidator.MAX_LENGTH);
            builder.HasMany<Route>("_routes").WithOne();
            builder.HasMany<Tariffes>("_tariffes").WithOne();
            builder.HasMany<Buyer>("_buyers").WithOne();

            builder.Ignore(x => x.Buyers);
            builder.Ignore(x => x.TariffZones);
            builder.Ignore(x => x.Routes);
        }
    }
}
