
using TrainStation.Domain.Entities.Base;
using TrainStation.Domain.Enums;
using TrainStation.Domain.Exceptions;
using TrainStation.ValueObjects;


namespace TrainStation.Domain.Entities
{
    public class Buyer : Entity<Guid>
    {


        public LastName LastName { get; private set; }

        public FirstName FirstName { get; private set; }

        public Administrator Administrator { get; }

        private readonly ICollection<Ticket> _buyerTickets = [];

        public IReadOnlyCollection<Ticket> BuyerTickets =>
            _buyerTickets.ToList().AsReadOnly();


        protected Buyer(Guid id, LastName buyerLastName, FirstName buyerFirstName, Administrator administrator) : base(id)
        {
            LastName = buyerLastName ?? throw new ArgumentNullValueException(nameof(buyerLastName));
            FirstName = buyerFirstName ?? throw new ArgumentNullValueException(nameof(buyerFirstName)); //  
            Administrator = administrator ?? throw new ArgumentNullException(nameof(administrator));
            administrator.AddBuyer(this);
        }

        protected Buyer()
        {

        }
        public Buyer(LastName buyerLastName, FirstName buyerFirstName, Administrator administrator)
            : this(Guid.NewGuid(), buyerLastName, buyerFirstName, administrator)
        {

        }
        internal bool ChangeLastName(LastName newBuyerLastName)
        {
            if (LastName == newBuyerLastName) return false;
            LastName = newBuyerLastName;
            return true;
        }

        internal bool ChangeFirstName(FirstName newBuyerFirstName)
        {
            if (FirstName == newBuyerFirstName) return false;
            FirstName = newBuyerFirstName;
            return true;
        }

        public Ticket BuyTicket(Station startStation, Station endStation, TicketTypeNaming ticketTypeNaming)
        {
            // Добавить Исключения, если переданы в параметры null
            Ticket ticket = new(DateTime.Now, startStation, endStation, this, ticketTypeNaming);
            _buyerTickets.Add(ticket);
            return ticket;
        }

    }
}
