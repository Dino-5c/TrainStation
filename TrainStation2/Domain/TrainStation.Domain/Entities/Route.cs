
using TrainStation.Domain.Entities.Base;
using TrainStation.Domain.Exceptions;
using TrainStation.ValueObjects;


namespace TrainStation.Domain.Entities
{
    /// <summary>
    /// Представляет Маршрут
    /// </summary>
    public class Route : Entity<Guid>
    {
        /// <summary>
        /// Название маршрута
        /// </summary>
        public RoName RouteName { get; private set; }

        /// <summary>
        /// Администратор, который добавил сущность
        /// </summary>
        public Administrator Administrator { get; }

        /// <summary>
        /// Коллекция станций
        /// </summary>
        private readonly ICollection<Station> _stations = []; // Список станций


        public IReadOnlyCollection<Station> Stations =>
            _stations.ToList().AsReadOnly();
        public Route(RoName routeName, Administrator administrator) : this(Guid.NewGuid(), routeName, administrator)
        {

        }

        protected Route(Guid id, RoName routeName, Administrator administrator)
        {
            RouteName = routeName ?? throw new ArgumentNullValueException(nameof(routeName));
            Administrator = administrator ?? throw new ArgumentNullValueException(nameof(administrator));
        }
        protected Route()
        {

        }


        /// <summary>
        /// Изменение названия маршрута.
        /// </summary>
        /// <param name="routeName">Название маршрута.</param>
        /// <returns>Возвращается true, если получилось изменить название маршрута. В другом случае возвращается false</returns>
        internal bool SetRouteName(RoName routeName/*, Administrator administrator*/)
        {
            // if (route == null) return false;
            // throw new ArgumentNullValueException(nameof(route));
            // if(administrator == typeof(Administrator))
            if (RouteName == routeName) return false;
            RouteName = routeName;
            return true;
        }

        public RoName GetRouteName()
        {
            return RouteName;
        }

        //
        public bool AddStation(Station station)
        {
            if (station == null) return false;
            _stations.Add(station);
            return true;
        }

        public bool DeleteStation(Station station)
        {
            if (station == null) return false;
            _stations.Remove(station);
            return true;
        }

    }
}
