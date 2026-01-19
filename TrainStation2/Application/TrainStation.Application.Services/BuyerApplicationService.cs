using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Buyer;
using TrainStation.Application.Services.Abstractions;
using TrainStation.Domain.Entities;
using TrainStation.Application.Services.Abstractions.Base;
using TrainStation.Repositories.Abstractions;

namespace TrainStation.Application.Services
{
    public class BuyerApplicationService(
        IRepository<Buyer, Guid> buyerRepository,
        IRepository<Administrator, Guid> administratorRepository,
        IMapper mapper) : IApplicationService<BuyerModel, CreateBuyerModel, Guid>
    {
        /// <summary>
        /// Получение по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BuyerModel?> GetModelByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var buyer = await buyerRepository.GetByIdAsync(id, cancellationToken);
            return buyer is null ? null : mapper.Map<BuyerModel>(buyer);
        }

        /// <summary>
        /// Получение всех моделей
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<BuyerModel>> GetModelsAsync(CancellationToken cancellationToken)
            => (await buyerRepository.GetAllAsync(cancellationToken, true))
            .Select(mapper.Map<BuyerModel>);

        /// <summary>
        /// Создание покупателя
        /// </summary>
        /// <param name="buyerInformation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BuyerModel?> CreateModelAsync(CreateBuyerModel buyerInformation, CancellationToken cancellationToken = default)
        {

            var administrator = await administratorRepository.GetByIdAsync(buyerInformation.AdministratorId, cancellationToken);
            if (administrator is null)
                return null;
            var buyer = administrator.AddBuyer(
                new(buyerInformation.BuyerFirstName),
                new(buyerInformation.BuyerLastName));

            if (buyer is null)
                return null;

            // var updatedAdministrator = await administratorRepository.UpdateAsync(administrator, cancellationToken); // Обновление администратора

            var createdBuyer = await buyerRepository.AddAsync(buyer, cancellationToken);
            return createdBuyer is null ? null : mapper.Map<BuyerModel>(createdBuyer);
        }

        /// <summary>
        /// Обновление информации о покупателе (имя, фамилия)
        /// </summary>
        /// <param name="buyerInformation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> UpdateModelAsync(BuyerModel buyerInformation, CancellationToken cancellationToken = default)
        {
            var buyer = await buyerRepository.GetByIdAsync(buyerInformation.Id, cancellationToken);
            if (buyer is null)
                return false;

            var changed = false;

            // Фамилия: меняем только если другая
            if (buyer.LastName.Value != buyerInformation.BuyerLastName)
            {
                var okLastName = buyer.ChangeLastName(new(buyerInformation.BuyerLastName));
                if (!okLastName)
                    return false;

                changed = true;
            }

            // Имя: меняем только если другое
            if (buyer.FirstName.Value != buyerInformation.BuyerFirstName)
            {
                var okFirstName = buyer.ChangeFirstName(new(buyerInformation.BuyerFirstName));
                if (!okFirstName)
                    return false;

                changed = true;
            }

            // Если вообще ничего не изменили — можно вернуть false (или true)
            if (!changed)
                return true;

            return await buyerRepository.UpdateAsync(buyer, cancellationToken);

        }


        /// <summary>
        /// Удаление покупателя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> DeleteModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var buyer = await buyerRepository.GetByIdAsync(id, cancellationToken);
            if (buyer is null)
                return false;
            var administrator = await administratorRepository.GetByIdAsync(buyer.Administrator.Id, cancellationToken);
            if (administrator is null)
                return false;
            // var isBuyerClear = administrator.DeleteBuyer(buyer);

            var updatedAdministrator = await administratorRepository.UpdateAsync(administrator, cancellationToken); // Обновление администратора

            return await buyerRepository.DeleteAsync(buyer, cancellationToken);
        }
    }
}
