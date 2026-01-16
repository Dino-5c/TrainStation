namespace TrainSation.WebHost.Requests.TariffZone
{
    public record class UpdateTariffZoneRequest(Guid Id, int TariffZoneName, decimal Price, int Distance, Guid AdministratorId)
    {
    }
}
