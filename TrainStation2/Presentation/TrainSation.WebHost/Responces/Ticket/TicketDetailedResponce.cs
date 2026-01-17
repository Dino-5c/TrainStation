using TrainStation.Application.Models.Ticket;

namespace TrainSation.WebHost.Responces.Ticket
{
    public record class TicketDetailedResponce(Guid Id, DateTime BuyDate,
        Guid StartStationId,
        Guid EndStationId,
        Guid BuyerId,
        TicketType TicketType,
        decimal Price,
        decimal PriceProcent)
    {
    }
}
