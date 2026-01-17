using TrainStation.Application.Models.Ticket;

namespace TrainSation.WebHost.Responces.Buyer
{
    public record class BuyerDetailedResponce(
        Guid Id,
        string BuyerLastName,
        string BuyerfirstName,
        Guid AdministratorId,
        IEnumerable<TicketModel> Tickets)
    {
    }
}
