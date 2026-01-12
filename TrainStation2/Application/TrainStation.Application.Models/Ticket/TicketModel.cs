using TrainStation.Application.Models.Base;

namespace TrainStation.Application.Models.Ticket
{

    public record class TicketModel(
        Guid Id,
        DateTime BuyDate,
        Guid StartStationId,
        Guid EndStationId,
        Guid BuyerId,
        TicketType TicketType,
        decimal Price,
        decimal PriceProcent
        ) : IModel<Guid>
    {
    }
}
