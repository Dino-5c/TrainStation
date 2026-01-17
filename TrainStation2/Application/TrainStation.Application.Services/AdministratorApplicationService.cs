using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Administrator;
using TrainStation.Application.Services.Abstractions;
using TrainStation.Domain.Entities;
using TrainStation.Repositories.Abstractions;
using TrainStation.Application.Services.Abstractions.Base;

namespace TrainStation.Application.Services
{
    public class AdministratorApplicationService(
        IRepository<Administrator, Guid> administratorRepository, IMapper mapper) : IApplicationService<AdministratorModel, CreateAdministratorModel, Guid>
    {
        /// <summary>
        /// Получение всех администраторов
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AdministratorModel>> GetModelsAsync(CancellationToken cancellationToken = default)
            => (await administratorRepository.GetAllAsync(cancellationToken, true))
            .Select(mapper.Map<AdministratorModel>);

        /// <summary>
        /// Получение модели администратора по Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AdministratorModel?> GetModelByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var administrator = await administratorRepository.GetByIdAsync(id, cancellationToken);
            return administrator is null ? null : mapper.Map<AdministratorModel>(administrator);
        }

        /// <summary>
        /// Добавление администратора
        /// </summary>
        /// <param name="administratorInformation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AdministratorModel?> CreateModelAsync(CreateAdministratorModel administratorInformation, CancellationToken cancellationToken = default)
        {
            // if (await administratorRepository.GetByIdAsync(administratorInformation)) // Проверка на существовал ли администратор с Guid. Администратор создаётся в доменном слое, в модели нет Guid, проверку делать не по такому принципу или не выполнять  
            Administrator administrator = new(new(administratorInformation.AdministratorLastName), new(administratorInformation.AdministratorFirstName));
            var createdAdministrator = await administratorRepository.AddAsync(administrator, cancellationToken);
            return createdAdministrator is null ? null : mapper.Map<AdministratorModel>(administrator);
        }

        /// <summary>
        /// Обновление администратора (имя, фамилия)
        /// </summary>
        /// <param name="administratorInformation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> UpdateModelAsync(AdministratorModel administratorInformation, CancellationToken cancellationToken = default)
        {
            var administrator = await administratorRepository.GetByIdAsync(administratorInformation.Id, cancellationToken);
            if (administrator is null)
                return false;

            var changed = false;

            // Фамилия: меняем только если другая
            if (administrator.AdministratorLastName.Value != administratorInformation.AdministratorLastName)
            {
                var okLastName = administrator.SetAdministratorLastName(new(administratorInformation.AdministratorLastName));
                if (!okLastName)
                    return false;

                changed = true;
            }

            // Имя: меняем только если другое
            if (administrator.AdministratorFirstName.Value != administratorInformation.AdministratorFirstName)
            {
                var okFirstName = administrator.SetAdministratorFirstName(new(administratorInformation.AdministratorFirstName));
                if (!okFirstName)
                    return false;

                changed = true;
            }

            // Если вообще ничего не изменили — можно вернуть false (или true)
            if (!changed)
                return true;

            return await administratorRepository.UpdateAsync(administrator, cancellationToken);
        }

        /// <summary>
        /// Удаление администратора
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> DeleteModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var administrator = await administratorRepository.GetByIdAsync(id, cancellationToken);
            return administrator is null ? false : await administratorRepository.DeleteAsync(administrator, cancellationToken);
        }
    }
}
