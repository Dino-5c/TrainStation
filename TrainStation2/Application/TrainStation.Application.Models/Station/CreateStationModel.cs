using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Base;

namespace TrainStation.Application.Models.Station
{
    public record class CreateStationModel(
        string StationName,
        Guid RouteId,
        Guid TariffZoneId,
        StationStatus StationStatus) : ICreateModel
    {
    }
}
