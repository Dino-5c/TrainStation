namespace TrainSation.WebHost.Responces.Station
{
    public record class StationShortResponce(Guid Id, string StationName, Guid RouteId, Guid TariffZoneId)
    {
    }
}
