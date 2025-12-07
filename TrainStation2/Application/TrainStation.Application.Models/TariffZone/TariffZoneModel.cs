
using TrainStation.Application.Models.Base;

namespace TrainStation.Application.Models.TariffZone
{
    public record class TariffZoneModel(
        Guid Id,
        int TarifZoneName,
        decimal Price,
        int Distance
        ) : IModel<Guid>
    {
    }
}
