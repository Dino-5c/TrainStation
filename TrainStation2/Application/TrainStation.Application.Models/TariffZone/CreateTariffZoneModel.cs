
using TrainStation.Application.Models.Base;

namespace TrainStation.Application.Models.TariffZone
{
    public record class CreateTariffZoneModel(
        
        int TarifZoneName,
        decimal Price,
        int Distance,
        Guid AdministratorId
        ) : ICreateModel
    {
    }
}
