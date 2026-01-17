namespace TrainSation.WebHost.Requests.TariffZone
{
    public record class CreateTariffZoneRequest(int TariffZoneName, int Distance, decimal Price, Guid AdministratorId)
    {
    }
}
