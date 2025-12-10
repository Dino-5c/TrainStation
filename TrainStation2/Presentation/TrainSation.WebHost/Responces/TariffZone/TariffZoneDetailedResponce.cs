namespace TrainSation.WebHost.Responces.TariffZone
{
    public record class TariffZoneDetailedResponce(
        Guid Id,
        int TarifZoneName,
        decimal Price,
        int Distance,
        Guid AdministratorId)       
        
    {

    }
}
