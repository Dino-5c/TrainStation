using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Base;
using TrainStation.Application.Models.Buyer;
using TrainStation.Application.Models.Route;
using TrainStation.Application.Models.TariffZone;

namespace TrainStation.Application.Models.Administrator
{
    public sealed record class AdministratorModel : IModel<Guid>
    {
        public Guid Id { get; set; }
        public string AdministratorLastName { get; set; }
        public string AdministratorFirstName { get; set; }
        public IEnumerable<RouteModel> Routes { get; init; }
        public IEnumerable<TariffZoneModel> TariffZones { get; init; }
        public IEnumerable<BuyerModel> Buyers { get; init; }
    }
}
