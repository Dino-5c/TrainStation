using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Ticket;
using TrainStation.Domain.Entities;
using TrainStation.Repositories.Abstractions;
using TrainStation.Application.Services.Abstractions.Base;

namespace TrainStation.Application.Services
{
    public class TicketApplicationService(
        IRepository<Ticket, Guid> ticketRepository, IRepository<Buyer, Guid> buyerRepository, IRepository<Station, Guid> stationRepository, IMapper mapper) : IApplicationService<TicketModel, CreateTicketModel, Guid>
    {
        /// <summary>
        /// Получение всех билетов
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TicketModel>> GetModelsAsync(CancellationToken cancellationToken = default)
            => (await ticketRepository.GetAllAsync(cancellationToken, true))
            .Select(mapper.Map<TicketModel>);
        
        /// <summary>
        /// Получение модели билета по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TicketModel?> GetModelByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var ticket = await ticketRepository.GetByIdAsync(id, cancellationToken);
            return ticket is null ? null : mapper.Map<TicketModel>(ticket);
        }

        /// <summary>
        /// Создание билета
        /// </summary>
        /// <param name="ticketInformation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TicketModel?> CreateModelAsync(CreateTicketModel ticketInformation, CancellationToken cancellationToken = default)
        {
            var buyer = await buyerRepository.GetByIdAsync(ticketInformation.BuyerId, cancellationToken);
            if (buyer is null)
                return null;
            
            var startStation = await stationRepository.GetByIdAsync(ticketInformation.StartStationId, cancellationToken);
            if (startStation is null)
                return null;

            var endStation = await stationRepository.GetByIdAsync(ticketInformation.EndStationId, cancellationToken);
            if (endStation is null)
                return null;

            var ticket = buyer.BuyTicket(startStation, endStation, (Domain.Enums.TicketTypeNaming)ticketInformation.TicketType);

            if (ticket is null)
                return null;

            // var updatedBuyer = await buyerRepository.UpdateAsync(buyer, cancellationToken); // Обновление покупателя

            var createdTicket = await ticketRepository.AddAsync(ticket, cancellationToken);
            return createdTicket is null ? null : mapper.Map<TicketModel>(createdTicket);
        }

        /// <summary>
        /// Обновление билета, нужно будет дописать
        /// </summary>
        /// <param name="ticketInformation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> UpdateModelAsync(TicketModel ticketInformation, CancellationToken cancellationToken = default)
        {
            var entityId1 = ticketRepository.GetByIdAsync(ticketInformation.Id, cancellationToken);
            if (entityId1 is null) return false;

            var entity = entityId1.Result;
            entity = mapper.Map<Ticket>(ticketInformation);
            return await ticketRepository.UpdateAsync(entity, cancellationToken); 
        }

        /// <summary>
        /// Удаление билета, нужно будет дописать
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> DeleteModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var ticket = await ticketRepository.GetByIdAsync(id, cancellationToken);
            return ticket is null ? false : await ticketRepository.DeleteAsync(ticket, cancellationToken);
        }
    }
}
