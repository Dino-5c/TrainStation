using TrainStation.Application.Models.Ticket;

namespace TrainSation.WebHost.Requests.Ticket
{
    public record class CreateTicketRequest(DateTime BuyDate, Guid StartStationId, Guid EndStationId, Guid BuyerId, TicketType TicketType)
    {
    }
}
