using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainStation.Domain.Entities;
using TrainStation.ValueObjects;
using TrainStation.ValueObjects.Validators;


namespace TrainStation.Infrastructure.EntityFramework.Configurations
{
    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.StationName)
                .IsRequired()
                .HasConversion(stationName => stationName.Value, str => new StationName(str))
                .HasMaxLength(StationNameValidator.MAX_LENGTH);
            builder.HasOne(x => x.Route).WithMany("_stations");
            builder.HasOne(x => x.TariffZone)
                .WithMany() // У Tariffes нет коллекции станций
                .HasForeignKey("TariffZoneId")
                .IsRequired(); // Связь один к одному? У станции одна тарифная зона, у тарифной зоны не обязательно должна быть станция
            builder.Property(x => x.StationStatus).IsRequired();
            builder.Ignore(x => x.IsFrozen);
            builder.Ignore(x => x.IsActive);
            builder.Navigation(x => x.Route).AutoInclude();


            /*  Настройка модели для автоматического включения свойств навигации. Navigation, AutoInclude.  Вы можете настроить в модели автоматическое включение свойства навигации при загрузке определенных сущностей
             * из базы данных, используя метод AutoInclude. Это аналогично тому, как если бы вы указывали Include для свойства навигации в
             * каждом запросе, где в результатах возвращается определенный тип сущности.*/
        }
    }
}
