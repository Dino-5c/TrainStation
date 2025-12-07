using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.ValueObjects;

namespace TrainStation.Domain.Exceptions
{
    internal class CoincidenceOfStartAndEndStationException(Guid ticketId, StationName startStationName, StationName endStationName)
        : InvalidOperationException($"It impossible to buy ticket number {ticketId}, because it for sales on one station - start station {startStationName} and end station {endStationName} are matched.")
    // InvalidOperationException: Исключение, которое выдается при вызове метода, недопустимого для текущего состояния объекта. Наследование: Object ==> Exception ==> SystemException ==> InvalidOperationException
    {
        public Guid TicketId => ticketId;
        public StationName StartStationName => startStationName;
        public StationName EndStationName => endStationName;
    }
}
