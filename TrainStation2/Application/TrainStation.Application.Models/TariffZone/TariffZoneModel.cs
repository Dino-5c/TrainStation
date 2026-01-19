
using TrainStation.Application.Models.Base;

namespace TrainStation.Application.Models.TariffZone
{
    public record class TariffZoneModel
        /*( Guid Id,
        int TarifZoneName,
        decimal Price,
        int Distance,
        Guid AdministratorId) */ 
         : IModel<Guid>
    {
        public Guid Id { get; init; }
        public int TarifZoneName { get; init; }
        public decimal Price { get; init; }
        public int Distance { get; init; }
        public Guid AdministratorId { get; init; } 
    }
}
