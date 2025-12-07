using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainStation.Domain.Entities;
using TrainStation.ValueObjects;

namespace TrainStation.Infrastructure.EntityFramework.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id); // Нужно добавить IsRequaried ?
            builder.Property(x => x.BuyDate).IsRequired().HasConversion
            (
                src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
            );
            builder.HasOne(x => x.StartStation)
                .WithMany()
                .HasForeignKey("StartStationId")
                .IsRequired();
            builder.HasOne(x => x.EndStation)
                .WithMany()
                .HasForeignKey("EndStationId")
                .IsRequired(); // 
            builder.HasOne(x => x.Buyer).WithMany("_buyerTickets");
            builder.Property(x => x.Price)
                .IsRequired()
                .HasConversion(price => price.Value, i => new Money(i));
            builder.Property(x => x.PriceProcent)
                .IsRequired()
                .HasConversion(pricePr => pricePr.Value, s => new PriceProcent(s));
            // builder.HasMany<Tariffes>("_tariffZones").WithOne(x => x.); // Тарифы связаны с билетами
            builder.Property(x => x.TicketType).IsRequired();
            builder.Ignore(x => x.IsAnimal); // Не записываем свойства, где поле bool, в котором тип билета
            builder.Ignore(x => x.IsFull);
            builder.Ignore(x => x.IsBuggage);
            builder.Ignore(x => x.IsLgot);
            // Как связать список тарифов с администратором? Так как у него есть тарифы
            builder.Navigation(x => x.Buyer).AutoInclude();
        }

    }
}
