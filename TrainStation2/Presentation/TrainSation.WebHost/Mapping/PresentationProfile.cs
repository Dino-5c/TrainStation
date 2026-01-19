using AutoMapper;
using TrainSation.WebHost.Requests.Administrator;
using TrainSation.WebHost.Requests.Buyer;
using TrainSation.WebHost.Requests.Route;
using TrainSation.WebHost.Requests.Station;
using TrainSation.WebHost.Requests.TariffZone;
using TrainSation.WebHost.Requests.Ticket;
using TrainSation.WebHost.Responces.Administrator;
using TrainSation.WebHost.Responces.Buyer;
using TrainSation.WebHost.Responces.Route;
using TrainSation.WebHost.Responces.Station;
using TrainSation.WebHost.Responces.TariffZone;
using TrainSation.WebHost.Responces.Ticket;
using TrainStation.Application.Models.Administrator;
using TrainStation.Application.Models.Buyer;
using TrainStation.Application.Models.Route;
using TrainStation.Application.Models.Station;
using TrainStation.Application.Models.TariffZone;
using TrainStation.Application.Models.Ticket;

namespace TrainSation.WebHost.Mapping
{
    public class PresentationProfile : Profile
    {
        public PresentationProfile()
        {
            CreateMap<TariffZoneModel, TariffZoneShortResponce>();
            CreateMap<TariffZoneModel, TariffZoneDetailedResponce>();
            CreateMap<CreateTariffZoneRequest, CreateTariffZoneModel>();
            CreateMap<CreateTariffZoneModel, TariffZoneShortResponce>();
            CreateMap<UpdateTariffZoneRequest, TariffZoneModel>();

            CreateMap<RouteModel, RouteShortResponce>();
            CreateMap<RouteModel, RouteDetailedResponce>();
            CreateMap<CreateRouteRequest, CreateRouteModel>();
            CreateMap<CreateRouteModel, RouteShortResponce>();
            CreateMap<UpdateRouteRequest, RouteModel>();

            CreateMap<AdministratorModel, AdministratorShortResponce>();
            CreateMap<AdministratorModel, AdministratorDetailedResponce>();
            CreateMap<CreateAdministratorRequest, CreateAdministratorModel>();
            CreateMap<CreateAdministratorModel, AdministratorShortResponce  >();
            CreateMap<UpdateAdministratorRequest, AdministratorModel>();

            CreateMap<TicketModel, TicketShortResponce>();
            CreateMap<TicketModel, TicketDetailedResponce>();
            CreateMap<CreateTicketRequest, CreateTicketModel>();
            CreateMap<CreateTicketModel, TicketShortResponce>();

            CreateMap<BuyerModel, BuyerShortResponce>();
            CreateMap<BuyerModel,BuyerDetailedResponce>();
            CreateMap<CreateBuyerRequest, CreateBuyerModel>();
            CreateMap<CreateBuyerModel, BuyerShortResponce>();
            CreateMap<UpdateBuyerRequest, BuyerModel>();

            CreateMap<StationModel, StationShortResponce>();
            CreateMap<StationModel, StationDetailedResponce>();
            CreateMap<CreateStationModel, StationShortResponce>();
            CreateMap<CreateStationRequest, CreateStationModel>();
            CreateMap<UpdateStationRequest, StationModel>();
        }
    }
}
