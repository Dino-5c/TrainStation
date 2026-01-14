using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Buyer;
using TrainStation.Application.Services.Abstractions;
using TrainStation.Domain.Entities;
using TrainStation.Repositories.Abstractions;

namespace TrainStation.Application.Services
{
    public class BuyerApplicationService(
        IRepository<Buyer, Guid> buyerRepository,
        IRepository<Administrator, Guid> administratorRepository,
        IMapper mapper) : IBuyerApplicationService
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
                new(buyerInformation.FirstName),
                new(buyerInformation.LastName));

            if (buyer is null)
                return null;

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

            var okLastName = buyer.ChangeLastName(new(buyerInformation.LastName));
            var okFirstName = buyer.ChangeFirstName(new(buyerInformation.FirstName));

            if (!okLastName || !okFirstName)
                return false;
            buyer = mapper.Map<Buyer>(buyerInformation);
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
            administrator.DeleteBuyer(buyer);
            return administrator is null ? false : await administratorRepository.DeleteAsync(administrator, cancellationToken);
        }
    }
}
