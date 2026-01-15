using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TrainSation.WebHost.Helpers;
using TrainSation.WebHost.Mapping;
using TrainStation.Application.Models.Administrator;
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

            builder.Services.AddScoped<IApplicationService<AdministratorModel, CreateAdministratorModel, Guid>, AdministratorApplicationService>();

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
