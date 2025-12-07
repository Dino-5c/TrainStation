using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.TariffZone;

namespace TrainStation.Application.Services.Abstractions
{
    public interface ITariffZoneApplicationService
    {
        Task<TariffZoneModel?> GetTariffZoneByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<TariffZoneModel>> GetTariffZonesAsync(CancellationToken cancellationToken);

        Task<TariffZoneModel?> CreateTariffZoneAsync(CreateTariffZoneModel auctionLotInformation, CancellationToken cancellationToken);

        Task<bool> UpdateTariffZoneAsync(TariffZoneModel auctionLot, CancellationToken cancellationToken);

        Task<bool> DeleteTariffZoneAsync(Guid id, CancellationToken cancellationToken);
    }
}
