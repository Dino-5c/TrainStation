
using TrainStation.Application.Models.Base;

namespace TrainStation.Application.Models.TariffZone
{
    public sealed record class CreateTariffZoneModel : ICreateModel        
        /*( int TarifZoneName,
        int Distance,        
        decimal Price,
        Guid AdministratorId )*/
        
    {
        
        public int TarifZoneName { get; set; }
        public decimal Price { get; init; }
        public int Distance { get; set; }
        public Guid AdministratorId { get; init; } 
    }
}
