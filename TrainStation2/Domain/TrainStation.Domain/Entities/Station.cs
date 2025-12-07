
using TrainStation.Domain.Entities.Base;
using TrainStation.Domain.Enums;
using TrainStation.Domain.Exceptions;
using TrainStation.ValueObjects;

namespace TrainStation.Domain.Entities
{
    public class Station : Entity<Guid>
    {

        public StationName StationName { get; private set; }

        public Route Route { get; private set; }

        public Tariffes TariffZone { get; private set; }

        public StationStatus StationStatus { get; private set; }

        public Guid TariffZoneId { get; private set; }

        public bool IsActive => StationStatus == StationStatus.Active;

        public bool IsFrozen => StationStatus == StationStatus.Frozen;

        protected Station(Guid stationId, StationName stationName, Route route, Tariffes tariffZone, StationStatus stationStatus) : base(stationId)
        {
            StationName = stationName ?? throw new ArgumentNullValueException(nameof(stationName));
            Route = route ?? throw new ArgumentNullValueException(nameof(route));
            TariffZone = tariffZone ?? throw new ArgumentNullValueException(nameof(tariffZone));
            TariffZoneId = tariffZone.Id;
            StationStatus = stationStatus /* ?? throw new ArgumentNullValueException(nameof(stationStatus)) */;

        }
        public Station(StationName stationName, Route route, Tariffes tariffZone, StationStatus stationStatus)
            : this(Guid.NewGuid(), stationName, route, tariffZone, stationStatus)
        {

        }
        protected Station()
        {

        }

        /// <summary>
        /// Изменение названия станции.
        /// </summary>
        /// <param name="stationName">Название станции.</param>
        /// <returns>Возвращается true, если получилось изменить название станции. В другом случае возвращается false</returns>
        internal bool SetStationName(StationName stationName)
        {
            if (stationName == null) return false;
            if (StationName == stationName) return false;
            StationName = stationName;
            return true;
        }
        /// <summary>
        /// Изменение принадлежности станции к какому-то маршруту.
        /// </summary>
        /// <param name="routeId">Маршрута.</param>
        /// <returns>Возвращается true, если получилось изменить маршрут у станции. В другом случае возвращается false</returns>
        internal bool SetRoute(Route route)
        {
            if (route == null) return false;
            if (Route == route) return false;
            Route = route;
            return true;
        }
        /// <summary>
        /// Изменение состояния станции.
        /// </summary>
        /// <param name="stationStatus">Состояние станции(активна, заморожена).</param>
        /// <returns>Возвращается true, если получилось изменить состояние у станции. В другом случае возвращается false</returns>
        public bool ChangeStationStatus(StationStatus stationStatus) // internal 
        {
            if (StationStatus == stationStatus) return false;
            StationStatus = stationStatus;
            return true;
        }
        /// <summary>
        /// Изменение тарифной зоны станции.
        /// </summary>
        /// <param name="tariffZone">Номер тарифной зоны.</param>
        /// <returns>Возвращается true, если получилось изменить тарифную зону станции. В другом случае возвращается false</returns>
        public bool SetTariffZone(Tariffes tariffZone)
        {
            if (TariffZone == tariffZone) return false;
            TariffZone = tariffZone;
            return true;
        }

    }
}
