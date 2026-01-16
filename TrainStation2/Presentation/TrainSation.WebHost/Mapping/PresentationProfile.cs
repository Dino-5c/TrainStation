using AutoMapper;
using TrainSation.WebHost.Requests.Administrator;
using TrainSation.WebHost.Requests.Route;
using TrainSation.WebHost.Requests.TariffZone;
using TrainSation.WebHost.Responces.Administrator;
using TrainSation.WebHost.Responces.Route;
using TrainSation.WebHost.Responces.TariffZone;
using TrainStation.Application.Models.Administrator;
using TrainStation.Application.Models.Route;
using TrainStation.Application.Models.TariffZone;

namespace TrainSation.WebHost.Mapping
{
    public class PresentationProfile : Profile
    {
        public PresentationProfile()
        {
            CreateMap<TariffZoneModel, TariffZoneShortResponce>();
            CreateMap<TariffZoneModel, TariffZoneDetailedResponce>();
            CreateMap<CreateTariffZoneRequest, CreateTariffZoneModel>();
            CreateMap<CreateTariffZoneModel, TariffZoneDetailedResponce>();

            CreateMap<RouteModel, RouteShortResponce>();
            CreateMap<RouteModel, RouteDetailedResponce>();
            CreateMap<CreateRouteRequest, CreateRouteModel>();
            CreateMap<CreateRouteModel, RouteShortResponce>();

            CreateMap<AdministratorModel, AdministratorShortResponce>();
            CreateMap<AdministratorModel, AdministratorDetailedResponce>();
            CreateMap<CreateAdministratorRequest, CreateAdministratorModel>();
            CreateMap<CreateAdministratorModel, AdministratorShortResponce>();

        }
    }
}
