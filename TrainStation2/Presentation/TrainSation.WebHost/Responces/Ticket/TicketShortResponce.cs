using TrainStation.Application.Models.Ticket;

namespace TrainSation.WebHost.Responces.Ticket
{
    public record class TicketShortResponce(Guid Id, DateTime BuyDate, Guid StartStarionId,
        Guid EndStationId, Guid BuyerId, TicketType TicketType, decimal Price)
    {
    }
}
