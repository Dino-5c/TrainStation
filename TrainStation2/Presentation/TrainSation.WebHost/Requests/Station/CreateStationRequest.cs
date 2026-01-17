namespace TrainSation.WebHost.Requests.Station
{
    public record class CreateStationRequest(string StationName, Guid RouteId, Guid TariffZoneId)
    {
    }
}
