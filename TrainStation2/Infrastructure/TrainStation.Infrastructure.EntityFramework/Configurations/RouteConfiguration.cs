using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainStation.Domain.Entities;
using TrainStation.ValueObjects;

namespace TrainStation.Infrastructure.EntityFramework.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.RouteName)
                .IsRequired()
                .HasConversion(routeName => routeName.Value, strin => new RoName(strin));
            builder.HasMany<Station>("_stations").WithOne(x => x.Route);
            builder.HasOne(x => x.Administrator).WithMany("_routes");
            builder.Navigation(x => x.Administrator).AutoInclude();
            builder.Ignore(x => x.Stations);
        }
    }
}
