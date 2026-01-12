using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Base;

namespace TrainStation.Application.Models.Station
{
    public enum StationStatus
    {
        Active = 1,
        Frozen = 2
    }
    public record class StationModel(
        Guid Id,
        string StationName,
        Guid RouteId,
        Guid TariffZoneId,
        StationStatus StationStatus) : IModel<Guid>
    {
    }



}
