using TrainStation.Application.Models.Ticket;

namespace TrainSation.WebHost.Requests.Ticket
{
    public record class UpdateTicketRequest(Guid Id, DateTime BuyDate, Guid StartStationId, Guid EndStationId, Guid BuyerId, TicketType TicketType, decimal Price, decimal PriceProcent)
    {
    }
}
