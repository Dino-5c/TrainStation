using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.ValueObjects;

namespace TrainStation.Domain.Entities
{
    class AnimalTicket : Ticket
    {

        public TicketType Tickettype { get; }

        public PriceProcent PriceProcent { get; private set; }

        //public AnimalTicket(Guid ticketId, DateTime buyDate, Guid startStation, Guid endStation, Guid buyerId , TicketType tickettype, PriceProcent priceProcent) : base(ticketId, buyDate, startStation, endStation, buyerId)
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
