
using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Exceptions;

namespace TrainStation.ValueObjects.Validators
{
    public class TarifZoneNamesValidator : IValidator<int>
    {

        /// <summary>
        /// Проверяет строку, чтобы убедиться, что она не является нулевой, пустой и не состоит только из пробелов.
        /// </summary>
        /// <param name="value">Строка, в которой находятся данные.</param>
        /// <exception cref="ArgumentNullOrWhiteSpaceException">Исключение, которое создаётся что если, строка нулевая или состоит из пробелов.</exception>
        /// <exception cref="TarifZoneNameLongValueException">Исключение, которое создаётся, если длина названия тарифной зоны больше допустимой длины.</exception>
        /// <exception cref="TarifZoneNameShortValueException">Исключение, которое создаётся, если длина названия тарифной зоны меньше допустимой длины.</exception>
        public void Validate(int value)
        {
            if (value < 0)
                throw new TarifZoneNameNonPositiveException(ExceptionMessages.TARIFF_ZONE_NUMBER_NOT_POSITIVE, nameof(value), value);
        }


    }
}
