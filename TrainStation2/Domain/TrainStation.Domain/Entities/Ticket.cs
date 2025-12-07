
using TrainStation.Domain.Entities.Base;
using TrainStation.Domain.Enums;
using TrainStation.Domain.Exceptions;
using TrainStation.ValueObjects;

namespace TrainStation.Domain.Entities
{
    public class Ticket : Entity<Guid>
    {
        // const decimal FullProcent = 1.00m;

        public DateTime BuyDate { get; }

        public Station StartStation { get; private set; }
        public Guid StartStationId { get; set; }
        public Station EndStation { get; private set; }
        public Guid EndStationId { get; set; }
        public Buyer Buyer { get; }

        public Money Price { get; private set; }

        public TicketTypeNaming TicketType { get; private set; }

        public PriceProcent PriceProcent { get; private set; }

        /// <summary>
        /// Администратор, который добавил сущность
        /// </summary>
        // public Administrator Administrator { get; }

        // private static readonly ICollection<Tariffes> _tariffZones = [];

        public bool IsAnimal => TicketType == TicketTypeNaming.Animal;

        public bool IsBuggage => TicketType == TicketTypeNaming.Buggage;

        public bool IsLgot => TicketType == TicketTypeNaming.Lgot;

        public bool IsFull => TicketType == TicketTypeNaming.Full;

        // public IReadOnlyCollection<Tariffes> TariffZones
        // => _tariffZones.ToList().AsReadOnly();

        /* private readonly ICollection<Route> _routes = []; */

        /// <summary>
        /// Конструктор создания Билета
        /// </summary>
        /// <param name="id">Номер билета</param>
        /// <param name="buyDate">Дата покупки билета</param>
        /// <param name="startStation">Начальная станция</param>
        /// <param name="endStation">Конечная станция</param>
        /// <param name="buyer">Покупатель</param>
        /// <exception cref="CoincidenceOfStartAndEndStationException">Исключение, которое срабатывает, если начальная и конечная станции совпадают.</exception>
        protected Ticket(Guid id, DateTime buyDate, Station startStation, Station endStation, Buyer buyer, TicketTypeNaming ticketType) : base(id)
        {
            // Сделать: Проверка, что станции находятся на одном маршруте
            if (startStation == endStation) throw new CoincidenceOfStartAndEndStationException(this.Id, startStation.StationName, endStation.StationName); // Нужно?           
            if (!(startStation.Route == endStation.Route))
                throw new BuyTicketsOnDifferentRoutesStations(this.Id, startStation.StationName, endStation.StationName);
            if (!endStation.IsActive) //
                throw new BuyTicketOnNotActiveEndStationException(this.Id, endStation.StationName);
            if (!startStation.IsActive)
                throw new BuyTicketOnNotActiveStartStationException(this.Id, startStation.StationName);
            // Проверка, если номер тарифной зоны начальной станции больше номера тарифной зоны конечной станции, то станции меняются местами, чтобы не изменять конструктор класса
            if (startStation.TariffZone.TariffName > endStation.TariffZone.TariffName)
            {
                var tmp = startStation;
                startStation = endStation;
                endStation = tmp;
            }

            BuyDate = buyDate; // Проверка даты, времени покупки билета
            StartStation = startStation ?? throw new ArgumentNullValueException(nameof(startStation));
            StartStationId = startStation.Id;
            SetEndStation(endStation);
            EndStationId = endStation.Id;
            TicketType = ticketType;
            Buyer = buyer ?? throw new ArgumentNullValueException(nameof(buyer));
            PriceProcent = SetPriceProcent();
            // Добавить в список билетов



            if (endStation.TariffZone.Id == startStation.TariffZone.Id)
                Price = new Money(40m) * PriceProcent; // Если номера тарифных зон у конечной и начальной станций равны, то цена устанавливается миним. руб.
            else
            {
                // Смотрим в списке тарифных зон
                foreach (var tariffZone in buyer.Administrator.TariffZones)
                {
                    if ((endStation.TariffZone.TariffName - startStation.TariffZone.TariffName) <= new TarifZoneNames(2))
                        Price = startStation.TariffZone.Price * PriceProcent; //
                    if (tariffZone.TariffName == (endStation.TariffZone.TariffName - startStation.TariffZone.TariffName))
                        Price = tariffZone.Price * PriceProcent;

                }
            }



            /* TariffZones.Find(endStation.TariffZone.TariffName - startStation.TariffZone.TariffName);
            copyTariffes.SetTariffZoneName(endStation.TariffZone.TariffName - startStation.TariffZone.TariffName);
            Price = (tarifZone.) * PriceProcent; */
        }


        public PriceProcent SetPriceProcent(/*TicketTypeNaming ticketType*/)
        {
            PriceProcent priceProcent = new PriceProcent(1.0m);
            // if (IsFull) { priceProcent = new PriceProcent(1.00m); }
            if (IsBuggage) { priceProcent *= 2; }
            else if (IsAnimal) { priceProcent *= 2; }
            else if (IsLgot) { priceProcent *= 0.5m; }
            else { priceProcent *= 1; }
            return priceProcent;
        }



        // В конструкторе создаём Guid номер билета, така как создаём билет здесь, когда покупаем
        public Ticket(DateTime buyDate, Station startStation, Station endStation, Buyer buyer, TicketTypeNaming ticketType)
            : this(Guid.NewGuid(), buyDate, startStation, endStation, buyer, ticketType)
        {

        }

        protected Ticket()
        {

        }

        /// <summary>
        /// Изменение номера начальной станции (откуда отправляется поезд).
        /// </summary>
        /// <param name="startStation">Номер начальной станции.</param>
        /// <returns>Возвращается true, если получилось изменить номер начальной станции. В другом случае возвращается false</returns>
        public bool SetStartStation(Station startStation)
        {
            if (StartStation == startStation) return false;
            StartStation = startStation;
            return true;
        }

        /// <summary>
        /// Изменение номера конечной станции (до куда идёт поезд).
        /// </summary>
        /// <param name="endStation">Номер конечной станции.</param>
        /// <returns>Возвращается true, если получилось изменить номер конечной станции. В другом случае возвращается false</returns>
        public bool SetEndStation(Station endStation)
        {
            if (EndStation == endStation) return false;
            // if (EndStation.Id == StartStation.Id) return false;
            EndStation = endStation ?? throw new ArgumentNullValueException(nameof(endStation));
            return true;
        }

        //public static bool AddTariffZone(Tariffes tariffZone)
        //{
        //    if (tariffZone == null) return false;
        //    _tariffZones.Add(tariffZone);
        //    return true;
        //}
    }
}
