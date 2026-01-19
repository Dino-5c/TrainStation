namespace TrainSation.WebHost.Responces.TariffZone
{
    public record class TariffZoneDetailedResponce /*(
        Guid Id,
        int TarifZoneName,
        decimal Price,
        int Distance,
        Guid AdministratorId) */      
        
    {
        public Guid Id { get; init; }
        public int TarifZoneName { get; init; }
        public decimal Price { get; init; }
        public int Distance { get; init; }
        public Guid AdministratorId { get; init; }
    }
}
