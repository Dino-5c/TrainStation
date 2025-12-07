
using TrainStation.Domain.Entities.Base;
using TrainStation.Domain.Exceptions;
using TrainStation.ValueObjects;

namespace TrainStation.Domain.Entities
{
    public class Tariffes : Entity<Guid>
    {
        public TarifZoneNames TariffName { get; private set; }
        /// <summary>
        /// Стоимость проезда, цена распространяется до числа, указанного в Distance
        /// </summary>
        public Money Price { get; private set; }

        /// <summary>
        /// Расстояние зоны на котором действует цена, расстояние в километрах
        /// </summary>
        public Distance Distance { get; private set; }

        /// <summary>
        /// Администратор, который добавил сущность
        /// </summary>
        public Administrator Administrator { get; }

        public Tariffes(TarifZoneNames tarifZoneName, Money money, Distance distance, Administrator administrator)
            : this(Guid.NewGuid(), tarifZoneName, money, distance, administrator)
        {

        }

        protected Tariffes()
        {

        }

        protected Tariffes(Guid tariffId, TarifZoneNames tarifZoneName, Money money, Distance distance, Administrator administrator) : base(tariffId)
        {
            TariffName = tarifZoneName ?? throw new ArgumentNullValueException(nameof(tarifZoneName));
            Price = money ?? throw new ArgumentNullValueException(nameof(money));
            Distance = distance ?? throw new ArgumentNullValueException(nameof(distance));
            Administrator = administrator ?? throw new ArgumentNullValueException(nameof(administrator));
        }

        /// <summary>
        /// Изменение цены.
        /// </summary>
        /// <param name="money">Цена.</param>
        /// <returns>Возвращается true, если получилось изменить цену проезда в данном регионе. В другом случае возвращается false</returns>
        public bool SetPrice(Money money)
        {
            if (money == null) return false;
            if (Price == money) return false;
            Price = money;
            return true;
        }
        /// <summary>
        /// Изменение расстояния
        /// </summary>
        /// <param name="distance">Расстояние</param>
        /// <returns>Возвращается  true, если получилось изменить расстояние, на котором действует цена. В другом случае возвращается false</returns>
        public bool SetDistance(Distance distance)
        {
            if (distance == null) return false;
            if (Distance == distance) return false;
            Distance = distance;
            return true;
        }
        //

        public bool SetTariffZoneName(TarifZoneNames tarifZoneName)
        {
            if (tarifZoneName == null) return false;
            if (TariffName == tarifZoneName) return false;
            TariffName = tarifZoneName;
            return true;
        }

    }
}
