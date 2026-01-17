using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TrainSation.WebHost.Helpers;
using TrainSation.WebHost.Mapping;
using TrainStation.Application.Models.Administrator;
using TrainStation.Application.Models.Buyer;
using TrainStation.Application.Models.Route;
using TrainStation.Application.Models.Station;
using TrainStation.Application.Models.TariffZone;
using TrainStation.Application.Models.Ticket;
using TrainStation.Application.Services;
using TrainStation.Application.Services.Abstractions.Base;
using TrainStation.Application.Services.Mapping;
using TrainStation.Domain.Entities;
using TrainStation.Infrastructure.EntityFramework;
using TrainStation.Infrastructure.EntityFramework.RepositoriesEF;
using TrainStation.Repositories.Abstractions;

namespace TrainSation.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString(nameof(ApplicationDbContext));

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string for TrainStationMicroserviceDbContext is not configured.");
            }

            builder.Services.AddNpgsql<ApplicationDbContext>(connectionString, options =>
            {
                options.MigrationsAssembly("TrainStation.Infrastructure.EntityFramework");

            });

            builder.Services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Train station API",
                        Description = "The Train station API provides endpoints for auction management. This API allows you to put lots up for bidding and participate in an auction."
                    });
                });

            builder.Services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options.UseNpgsql(connectionString);
                });

            builder.Services.AddAutoMapper(typeof(PresentationProfile), typeof(ApplicationProfile));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IRepository<Administrator, Guid>, EFRepository<Administrator, Guid>>();
            builder.Services.AddScoped<IRepository<Buyer, Guid>, EFRepository<Buyer, Guid>>();
            builder.Services.AddScoped<IRepository<TrainStation.Domain.Entities.Route, Guid>, EFRepository< TrainStation.Domain.Entities.Route, Guid>>();
            builder.Services.AddScoped<IRepository<Station, Guid>, EFRepository<Station, Guid>>();
            builder.Services.AddScoped<IRepository<Tariffes, Guid>, EFRepository<Tariffes, Guid>>();
            builder.Services.AddScoped<IRepository<Ticket, Guid>, EFRepository<Ticket, Guid>>();

            builder.Services.AddScoped<IApplicationService<AdministratorModel, CreateAdministratorModel, Guid>, AdministratorApplicationService>();
            builder.Services.AddScoped<IApplicationService<BuyerModel, CreateBuyerModel, Guid>, BuyerApplicationService>();
            builder.Services.AddScoped<IApplicationService<RouteModel, CreateRouteModel, Guid>, RouteApplicationService>();
            builder.Services.AddScoped<IApplicationService<StationModel, CreateStationModel, Guid>, StationApplicationService>();
            builder.Services.AddScoped<IApplicationService<TariffZoneModel, CreateTariffZoneModel, Guid>, TariffZoneApplicationService>();
            builder.Services.AddScoped<IApplicationService<TicketModel, CreateTicketModel, Guid>, TicketApplicationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            // app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.MigrateDatabase<ApplicationDbContext>();

            app.Run();
        }
    }
}
