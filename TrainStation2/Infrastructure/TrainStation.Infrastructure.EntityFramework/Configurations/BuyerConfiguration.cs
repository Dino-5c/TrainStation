

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainStation.Domain.Entities;
using TrainStation.ValueObjects;
using TrainStation.ValueObjects.Validators;

namespace TrainStation.Infrastructure.EntityFramework.Configurations
{
    public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasConversion(firstName => firstName.Value, strin => new FirstName(strin))
                .HasMaxLength(FirstNameValidator.MAX_LENGTH);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasConversion(lastName => lastName.Value, strin => new LastName(strin))
                .HasMaxLength(LastNameValidator.MAX_LENGTH);
            builder.HasOne(x => x.Administrator).WithMany("_buyers");
            // Связь
            builder.HasMany<Ticket>("_buyerTickets").WithOne(x => x.Buyer);
            builder.Ignore(x => x.BuyerTickets);
            builder.Navigation(x => x.Administrator).AutoInclude();

            /* dotnet tool install --global dotnet-ef
        dotnet ef migrations add InitialCreate
        dotnet ef database update */
        }
    }
}
