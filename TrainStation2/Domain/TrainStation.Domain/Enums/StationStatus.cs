using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStation.Domain.Enums
{
    /// <summary>
    /// Перечисление состояний станции (активная (можно купить билет), замороженная (нельзя купить билет))
    /// </summary>
    public enum StationStatus
    {
        Active,
        Frozen
    }
}
