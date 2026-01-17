using TrainStation.Application.Models.Station;

namespace TrainSation.WebHost.Requests.Station
{
    public record class UpdateStationRequest(Guid Id, string StationName, Guid RouteId, Guid TariffZoneId, StationStatus StationStatus)
    {
    }
}
