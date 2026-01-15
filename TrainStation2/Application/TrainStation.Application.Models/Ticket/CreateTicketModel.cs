
using TrainStation.Application.Models.Base;

namespace TrainStation.Application.Models.Ticket
{
    public enum TicketType
    {
        Full,
        Animal,
        Lgot,
        Buggage
    }

    public record class CreateTicketModel(
        
        DateTime BuyDate,
        Guid StartStationId,
        Guid EndStationId,
        Guid BuyerId,
        TicketType TicketType
        ) : ICreateModel
    {
    }
}
