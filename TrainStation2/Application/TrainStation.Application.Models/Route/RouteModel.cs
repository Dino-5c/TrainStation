using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Base;
using TrainStation.Application.Models.Station;

namespace TrainStation.Application.Models.Route
{
    // sealed - означает, что дальше от класса нельзя наследоваться
    public sealed record class RouteModel : IModel<Guid>
    {
        public Guid Id { get; set; }
        public string RouteName { get; set; }
        public Guid AdministratorId { get; set; }
        public IEnumerable<StationModel> Stations { get; init; }
    }
}
