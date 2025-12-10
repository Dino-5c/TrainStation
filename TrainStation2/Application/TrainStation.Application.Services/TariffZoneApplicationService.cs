using AutoMapper;
using TrainStation.Application.Models.TariffZone;
using TrainStation.Application.Services.Abstractions.Base;
using TrainStation.Domain.Entities;
using TrainStation.Repositories.Abstractions;
using TrainStation.ValueObjects;

namespace TrainStation.Application.Services
{
    public class TariffZoneApplicationService( 
         IRepository<Tariffes, Guid> tariffZoneRepository,
        IRepository<Administrator, Guid> administratorRepository /*IAdministratorRepository*/, IMapper mapper)
        : IApplicationService<TariffZoneModel, CreateTariffZoneModel, Guid>
    {
        // Получение модели по id
        public async Task<TariffZoneModel?> GetModelByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var tariffZone = await tariffZoneRepository.GetByIdAsync(id, cancellationToken);
            return tariffZone is null? null : mapper.Map<TariffZoneModel>(tariffZone);
        }
        // Получение всех моделей
        public async Task<IEnumerable<TariffZoneModel>>GetModelsAsync(CancellationToken cancellationToken = default)
         => (await tariffZoneRepository.GetAllAsync(cancellationToken, true))
            .Select(mapper.Map<TariffZoneModel>);

        // Создание тарифной зоны
        public async Task<TariffZoneModel?> CreateModelAsync(CreateTariffZoneModel crtTariffZoneModel, CancellationToken cancellationToken = default)
        {
            // Администратор, создающий модель
            var administrator = await administratorRepository.GetByIdAsync(crtTariffZoneModel.AdministratorId, cancellationToken);
            if (administrator is null)
                return null;

            // Создание здесь тарифной зоны
            var tariffZone = administrator.CreateTariffZone(
                new(crtTariffZoneModel.TarifZoneName), // можно просто написать в коде new(..) без точного типа
                new(crtTariffZoneModel.Price),
                new(crtTariffZoneModel.Distance));

            if (tariffZone is null)
                return null;

            // Добавление тарифной зоны
            var createdTariffZone = await tariffZoneRepository.AddAsync(tariffZone, cancellationToken);
            return createdTariffZone is null ? null : mapper.Map<TariffZoneModel>(createdTariffZone);
        }

        // Обновление значений в объекте Тарифной зоны
        public async Task<bool> UpdateModelAsync(TariffZoneModel tariffZoneModel, CancellationToken cancellationToken = default)
        {
            var administratorTask = administratorRepository.GetByIdAsync(tariffZoneModel.AdministratorId, cancellationToken);
            var tariffZoneTask = tariffZoneRepository.GetByIdAsync(tariffZoneModel.Id, cancellationToken);

            Task.WaitAll(administratorTask, tariffZoneTask);
            if (administratorTask.Result is null || tariffZoneTask.Result is not null) // tariffZoneTask. Result не null?
                return false;

            var administrator = administratorTask.Result;
            var tariffZone = tariffZoneTask.Result;
            var edirtionTariffZone = administrator.EditTariffZone(
                tariffZone!, // что значит tariffZone!
                new(tariffZoneModel.TarifZoneName),
                new(tariffZoneModel.Distance),
                new(tariffZoneModel.Price));

            if (edirtionTariffZone is null)
                return false;

            return await tariffZoneRepository.UpdateAsync(edirtionTariffZone, cancellationToken);
        }

        // Удаление модели
        public async Task<bool> DeleteModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            // Вызвать метод удаления с Администратора?
            var /*administrator*/  tariffZone = await tariffZoneRepository.GetByIdAsync(id, cancellationToken);
            return tariffZone is null ? false : await tariffZoneRepository.DeleteAsync(tariffZone, cancellationToken);
        }
    }
}
