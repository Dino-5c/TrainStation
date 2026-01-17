using TrainStation.Application.Models.Station;

namespace TrainSation.WebHost.Responces.Station
{
    public record class StationDetailedResponce(Guid Id, string StationName, Guid RouteId, Guid TariffZoneId, StationStatus StationStatus)
    {
    }
}
