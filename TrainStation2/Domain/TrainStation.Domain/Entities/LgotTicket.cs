using TrainStation.ValueObjects;

namespace TrainStation.Domain.Entities
{
    class LgotTicket : Ticket
    {
        public TicketType Tickettype { get; }

        public PriceProcent PriceProcent { get; private set; }

        //public LgotTicket(Guid ticketId, DateTime buyDate, Guid startStation, Guid endStation, Guid buyerId, TicketType tickettype, PriceProcent priceProcent) : base(ticketId, buyDate, startStation, endStation, buyerId)
        //{

        //}

        public bool SetPriceProcent(PriceProcent priceProcent)
        {
            if (PriceProcent == priceProcent) return false;
            PriceProcent = priceProcent;
            return true;
        }
    }
}
