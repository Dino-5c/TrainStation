using TrainStation.Application.Models.Buyer;
using TrainStation.Application.Models.Route;
using TrainStation.Application.Models.TariffZone;

namespace TrainSation.WebHost.Responces.Administrator
{
    public record class AdministratorDetailedResponce(
        Guid Id,
        string AdministratorLastName,
        string AdministratorFirstName,
        IEnumerable<BuyerModel> Buyers,
        IEnumerable<TariffZoneModel> TariffZones,
        IEnumerable<RouteModel> Routes)
    {
    }
}
