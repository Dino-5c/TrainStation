using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TrainStation.Domain.Entities;

namespace TrainStation.Infrastructure.EntityFramework
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Tariffes> TarifZones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
