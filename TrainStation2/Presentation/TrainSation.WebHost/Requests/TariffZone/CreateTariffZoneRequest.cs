namespace TrainSation.WebHost.Requests.TariffZone
{
    public record class CreateTariffZoneRequest(int tariffZoneName, int distance, decimal price, Guid administratorId)
    {
    }
}
