using AutoMapper;
using TrainStation.Application.Models.Administrator;
using TrainStation.Application.Models.Buyer;
using TrainStation.Application.Models.Route;
using TrainStation.Application.Models.Station;
using TrainStation.Application.Models.TariffZone;
using TrainStation.Application.Models.Ticket;
using TrainStation.Domain.Entities;

namespace TrainStation.Application.Services.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {

            CreateMap<Administrator, AdministratorModel>()
                .ForMember(dest => dest.AdministratorLastName, opt => opt.MapFrom(src => src.AdministratorLastName.Value))
                .ForMember(dest => dest.AdministratorFirstName, opt => opt.MapFrom(src => src.AdministratorFirstName.Value))
                .ForMember(dest => dest.Buyers, opt => opt.MapFrom(src => src.Buyers))
                .ForMember(dest => dest.Routes, opt => opt.MapFrom(src => src.Routes))
                .ForMember(dest => dest.TariffZones, opt => opt.MapFrom(src => src.TariffZones));

            CreateMap<Buyer, BuyerModel>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.Value))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.Value))
                .ForMember(dest => dest.Tickets, opt => opt.MapFrom(src => src.BuyerTickets));

            CreateMap<Route, RouteModel>()
                .ForMember(dest => dest.RouteName, opt => opt.MapFrom(src => src.RouteName.Value))
                .ForMember(dest => dest.Stations, opt => opt.MapFrom(src => src.Stations));

            CreateMap<Station, StationModel>()
                .ForMember(dest => dest.StationName, opt => opt.MapFrom(src => src.StationName.Value))
                .ForMember(dest => dest.StationStatus, opt => opt.MapFrom(src => src.StationStatus));

            CreateMap<Tariffes, TariffZoneModel>()
                .ForMember(dest => dest.TarifZoneName, opt => opt.MapFrom(src => src.TariffName.Value))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value))
                .ForMember(dest => dest.Distance, opt => opt.MapFrom(src => src.Distance.Value));

            CreateMap<Ticket, TicketModel>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value))
                .ForMember(dest => dest.PriceProcent, opt => opt.MapFrom(src => src.PriceProcent.Value))
                .ForMember(dest => dest.TicketType, opt => opt.MapFrom(src => src.TicketType));
        }

    }
}
