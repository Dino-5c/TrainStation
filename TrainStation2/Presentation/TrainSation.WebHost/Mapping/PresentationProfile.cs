using AutoMapper;
using TrainSation.WebHost.Requests.TariffZone;
using TrainSation.WebHost.Responces.TariffZone;
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
        }
    }
}
