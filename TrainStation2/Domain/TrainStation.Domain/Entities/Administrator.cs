
using TrainStation.Domain.Entities.Base;
using TrainStation.Domain.Enums;
using TrainStation.Domain.Exceptions;
using TrainStation.ValueObjects;


namespace TrainStation.Domain.Entities
{
    public class Administrator : Entity<Guid>
    {

        public LastName AdministratorLastName { get; private set; }

        public FirstName AdministratorFirstName { get; private set; }

        //public Administrator(Guid administratorId, LastName administratorLastName, FirstName administratorFirstName) : base(administratorId)
        //{
        //    AdministratorLastName = administratorLastName;
        //    AdministratorFirstName = administratorFirstName;
        //}

        private readonly ICollection<Route> _routes = [];

        // private readonly ICollection<Station> _stations = [];

        private readonly ICollection<Tariffes> _tariffes = [];

        // public readonly ICollection<Ticket> _tickets = [];

        private readonly ICollection<Buyer> _buyers = [];

        public IReadOnlyCollection<Route> Routes =>
            _routes.ToList().AsReadOnly();

        // public IReadOnlyCollection<Station> Stations =>
        // _stations.ToList().AsReadOnly();
        public IReadOnlyCollection<Tariffes> TariffZones =>
            _tariffes.ToList().AsReadOnly();

        //public IReadOnlyCollection<Ticket> Tickets =>
        //    _tickets.ToList().AsReadOnly();

        public IReadOnlyCollection<Buyer> Buyers =>
            _buyers.ToList().AsReadOnly();


        protected Administrator(Guid administratorId, LastName administratorLastName, FirstName administratorFirstName) : base(administratorId)
        {
            AdministratorLastName = administratorLastName ?? throw new ArgumentNullValueException(nameof(administratorLastName));
            AdministratorFirstName = administratorFirstName ?? throw new ArgumentNullValueException(nameof(administratorFirstName));
        }

        protected Administrator()
        {

        }
        public Administrator(LastName administratorLastName, FirstName administratorFirstName)
            : this(Guid.NewGuid(), administratorLastName, administratorFirstName)
        {

        }

        internal bool SetAdministratorLastName(LastName administratorLastName)
        {
            if (AdministratorLastName == administratorLastName) return false;
            AdministratorLastName = administratorLastName;
            return true;
        }

        internal bool SetAdministratorFirstName(FirstName administratorFirstName)
        {
            if (AdministratorFirstName == administratorFirstName) return false;
            AdministratorFirstName = administratorFirstName;
            return true;
        }



        public Route CreateRoute(RoName routeName)
        {
            Route route = new(routeName, this);
            _routes.Add(route);
            return route;
        }

        public bool DeleteRoute(Route route)
        {
            if (route == null) return false; // Если null, возвращается false
            // if (!_routes.Contains(route)) return false; // Если в списке нет такого маршрута, возвращается false
            _routes.Remove(route);
            return true;
        }
        public bool SetRouteName(Route route, RoName routeName, Administrator administrator)
        {
            if (route == null) return false;
            // if (!_routes.Contains(route)) return false; // Проверка, ести ли маршрут в списке маршрутов
            if (!route.SetRouteName(routeName)) return false;
            return true;
        }

        public Station CreateStation(StationName stationName, Route route, Tariffes tariffZone, StationStatus stationStatus)
        {
            Station station = new(stationName, route, tariffZone, stationStatus);
            //_stations.Add(station);
            route.AddStation(station); // Нужно добавить этот метод и сделать метод в классе Route публичным. Нужно сделать public в классе Route список станций.
            // Ticket ticket.TariffZones
            return station;
        }

        public bool DeleteStation(Station station, Route route)
        {
            if (station == null) return false;
            if (!route.Stations.Contains(station)) return false; // Нужно сделать проверку
            // _stations.Remove(station);
            route.DeleteStation(station);
            return true;
        }
        public bool SetStationName(Station station, StationName stationName /*, this */)
        {
            if (station == null) return false;
            // if (_stations.Contains(station)) return false;
            if (!station.SetStationName(stationName)) return false;
            return true;
        }

        public bool SetStationStatus(Station station, StationStatus stationStatus)
        {
            if (station == null) return false;
            // if (!_stations.Contains(station)) return false;
            if (!station.ChangeStationStatus(stationStatus)) return false;
            return true;
        }

        public bool SetTarifZoneInStation(Station station, Tariffes tariffZone)
        {
            if (station == null) return false;
            // if (!_stations.Contains(station)) return false;
            if (!station.SetTariffZone(tariffZone)) return false;
            return true;
        }

        public bool SetRoute(Station station, Route route)
        {
            if (station == null) return false;
            // if (!_stations.Contains(station)) return false;
            if (!station.SetRoute(route)) return false;
            return true;
        }

        public Tariffes CreateTariffZone(TarifZoneNames tariffZoneName, Money money, Distance distance)
        {
            Tariffes tariffe = new(tariffZoneName, money, distance, this);
            _tariffes.Add(tariffe);
            // Ticket.AddTariffZone(tariffe); // Добавляем тарифую зону в список в классе Билета
            return tariffe;
        }

        public bool DeleteTariffZone(Tariffes tariffZone)
        {
            if (tariffZone == null) return false;
            if (!_tariffes.Contains(tariffZone)) return false;
            _tariffes.Remove(tariffZone);
            return true;
        }
        public bool SetDistanceOnTariffZone(Tariffes tariffZone, Distance tariffZoneDistance)
        {
            if (tariffZone == null) return false;
            if (!_tariffes.Contains(tariffZone)) return false;
            // if (!tariffZone.SetDistance(tariffZoneDistance)) return false ;
            return true;
        }

        public bool SetPrice(Tariffes tariffZone, Money price)
        {
            if (tariffZone == null) return false;
            // if (!_tariffes.Contains(tariffZone)) return false;
            if (!tariffZone.SetPrice(price)) return false;
            return true;
        }

        public bool SetTarifZoneName(Tariffes tariffZone, TarifZoneNames tariffZoneName)
        {
            if (tariffZone == null) return false;
            // if (!_tariffes.Contains(tariffZone)) return false;
            if (!tariffZone.SetTariffZoneName(tariffZoneName)) return false;
            return true;
        }

        public bool AddBuyer(Buyer buyer)
        {
            if (buyer == null) return false;
            if (_buyers.Contains(buyer)) return false;
            _buyers.Add(buyer);
            return true;
        }

    }
}
