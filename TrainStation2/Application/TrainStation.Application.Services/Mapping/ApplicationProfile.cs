using AutoMapper;
using TrainStation.Application.Models.TariffZone;
using TrainStation.Domain.Entities;

namespace TrainStation.Application.Services.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {

            CreateMap<Tariffes, TariffZoneModel>()
                .ForMember(dest => dest.TarifZoneName, opt => opt.MapFrom(src => src.TariffName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Distance, opt => opt.MapFrom(src => src.Distance));
        }

    }
}
