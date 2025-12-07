using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.ValueObjects;

namespace TrainStation.Domain.Exceptions
{
    public class BuyTicketOnNotActiveStartStationException(Guid ticketId, StationName startStationName)
        : InvalidOperationException($"It impossible to buy ticket number {ticketId}, because station {startStationName} is not active (You can't buy ticket).")
    // InvalidOperationException: Исключение, которое выдается при вызове метода, недопустимого для текущего состояния объекта. Наследование: Object ==> Exception ==> SystemException ==> InvalidOperationException
    {
        public Guid TicketId => ticketId;
        public StationName StartStationName => startStationName;
    }
}
