using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Buyer;
using TrainStation.Application.Models.Ticket;
using TrainStation.Application.Services.Abstractions.Base;

namespace TrainStation.Application.Services.Abstractions
{
    public interface IBuyerApplicationService : IApplicationService<BuyerModel, CreateBuyerModel, Guid>
    {
        Task<TicketModel?> BuyTicketAsync(CreateTicketModel ticketInformation, CancellationToken cancellationToken = default);
    }
}
