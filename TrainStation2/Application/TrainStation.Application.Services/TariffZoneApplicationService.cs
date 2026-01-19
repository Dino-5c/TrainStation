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
        /// <summary>
        /// Получение модели по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TariffZoneModel?> GetModelByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var tariffZone = await tariffZoneRepository.GetByIdAsync(id, cancellationToken);
            return tariffZone is null? null : mapper.Map<TariffZoneModel>(tariffZone);
        }
        
        /// <summary>
        /// Получение всех моделей
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TariffZoneModel>>GetModelsAsync(CancellationToken cancellationToken = default)
         => (await tariffZoneRepository.GetAllAsync(cancellationToken, true))
            .Select(mapper.Map<TariffZoneModel>);

        /// <summary>
        /// Создание тарифной зоны
        /// </summary>
        /// <param name="crtTariffZoneModel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TariffZoneModel?> CreateModelAsync(CreateTariffZoneModel tariffZoneInformation, CancellationToken cancellationToken = default)
        {
            // Администратор, создающий модель
            var administrator = await administratorRepository.GetByIdAsync(tariffZoneInformation.AdministratorId, cancellationToken);
            if (administrator is null)
                return null;

            // Создание здесь тарифной зоны
            var tariffZone = administrator.CreateTariffZone(
                new(tariffZoneInformation.TarifZoneName), // можно просто написать в коде new(..) без точного типа
                new(tariffZoneInformation.Price),
                new(tariffZoneInformation.Distance));

            if (tariffZone is null)
                return null;

            // var updatedAdministrator = await administratorRepository.UpdateAsync(administrator, cancellationToken); // Обновление администратора

            // Добавление тарифной зоны
            var createdTariffZone = await tariffZoneRepository.AddAsync(tariffZone, cancellationToken);
            return createdTariffZone is null ? null : mapper.Map<TariffZoneModel>(createdTariffZone);
        }

        /// <summary>
        /// Обновление значений в объекте Тарифной зоны
        /// </summary>
        /// <param name="tariffZoneModel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> UpdateModelAsync(TariffZoneModel tariffZoneInformation, CancellationToken cancellationToken = default)
        {
            var administratorTask = administratorRepository.GetByIdAsync(tariffZoneInformation.AdministratorId, cancellationToken);
            var tariffZoneTask = tariffZoneRepository.GetByIdAsync(tariffZoneInformation.Id, cancellationToken);

            Task.WaitAll(administratorTask, tariffZoneTask);
            if (administratorTask.Result is null || tariffZoneTask.Result is null) // tariffZoneTask. Result не null?
                return false;

            var administrator = administratorTask.Result;
            var tariffZone = tariffZoneTask.Result;
            var editionTariffZone = administrator.EditTariffZone(
                tariffZone!, // tariffZone! значит - элемент существует
                new(tariffZoneInformation.TarifZoneName),
                new(tariffZoneInformation.Distance),
                new(tariffZoneInformation.Price));

            if (editionTariffZone is null)
                return false;

            return await tariffZoneRepository.UpdateAsync(editionTariffZone, cancellationToken);
        }

        /// <summary>
        /// Удаление модели
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> DeleteModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            // Вызвать метод удаления с Администратора?
            var /*administrator*/  tariffZone = await tariffZoneRepository.GetByIdAsync(id, cancellationToken);
            // if (tariffZone is null)
            //     return false;
            // Администратор, создающий модель
            // var administrator = await administratorRepository.GetByIdAsync(tariffZone.Administrator.Id, cancellationToken);
            // if (administrator is null)
            //     return false;

            /* var isTariffZoneClear = administrator.DeleteTariffZone(tariffZone); */
            // var updatedAdministrator = await administratorRepository.UpdateAsync(administrator, cancellationToken); // Обновление администратора

            return  tariffZone is null ? false : await tariffZoneRepository.DeleteAsync(tariffZone, cancellationToken);
        }
    }
}
