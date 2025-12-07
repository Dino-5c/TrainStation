
using TrainStation.Application.Models.Base;

namespace TrainStation.Application.Models.Ticket
{
    public record class CreateTicketModel(
        
        DateTime BuyDate,
        Guid StartStationid,
        Guid EndStationId,
        Guid Buyer,
        string Tickettype
        ) : ICreateModel
    {
    }
}
