namespace TrainSation.WebHost.Requests.TariffZone
{
    public record class UpdateTariffZoneRequest/*( Guid Id, int TariffZoneName, decimal Price, int Distance, Guid AdministratorId )*/
    {
        public Guid Id { get; set; }
        public int TarifZoneName { get; set; }
        public decimal Price { get; set; }
        public int Distance { get; set; }
        public Guid AdministratorId { get; set; }
    }
}
