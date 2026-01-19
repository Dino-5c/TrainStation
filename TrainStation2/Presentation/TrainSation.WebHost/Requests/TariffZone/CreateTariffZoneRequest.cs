namespace TrainSation.WebHost.Requests.TariffZone
{
    public record class CreateTariffZoneRequest(int TariffZoneName, decimal Price, int Distance, Guid AdministratorId)
    {


    }
}
