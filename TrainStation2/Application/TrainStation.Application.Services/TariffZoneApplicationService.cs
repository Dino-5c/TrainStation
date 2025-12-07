using TrainStation.Application.Models.TariffZone;
using TrainStation.Application.Services.Abstractions.Base;
using TrainStation.Domain.Entities;
using TrainStation.Repositories.Abstractions;

namespace TrainStation.Application.Services
{
    public class TariffZoneApplicationService(
        IRepository<Tariffes, Guid> tariffZoneRepository
        /* , IAdministratorRepository*/)
        : IApplicationService<TariffZoneModel, CreateTariffZoneModel, Guid>
    {
        public async Task<TariffZoneModel?> GetModelByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {

        }
        public async GetModelsAsync(CancellationToken cancellationToken = default)
        {

        }
    }
}
