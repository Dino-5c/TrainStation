using TrainStation.Application.Models.Station;

namespace TrainSation.WebHost.Responces.Route
{
    public record class RouteDetailedResponce(Guid Id, string RouteName, Guid AdministratorId, IEnumerable<StationModel> Stations)
    {
    }
}
