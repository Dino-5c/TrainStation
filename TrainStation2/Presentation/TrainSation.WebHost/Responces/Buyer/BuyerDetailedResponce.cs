using TrainStation.Application.Models.Ticket;

namespace TrainSation.WebHost.Responces.Buyer
{
    public record class BuyerDetailedResponce /*(
        Guid Id,
        string BuyerLastName,
        string BuyerfirstName,
        Guid AdministratorId,
        IEnumerable<TicketModel> Tickets) */
    {
        public Guid Id { get; init; }
        public string BuyerLastName { get; init; }
        public string BuyerFirstName { get; init; }
        public Guid AdministratorId { get; init; }

        public IEnumerable<TicketModel> Tickets { get; init; }
    }
}
