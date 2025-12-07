
using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Exceptions;

namespace TrainStation.ValueObjects.Validators
{
    /// <summary>
    /// Определяет метод, реализующий проверку десятичной дроби.
    /// </summary>
    public class PriceProcentValidator : IValidator<decimal>
    {
        /// <summary>
        /// Проверяет, что десятичная дробь не является отрицательной и не равна нулю.
        /// </summary>
        /// <param name="value">Десятичное значение.</param>
        /// <exception cref="PriceProcentNonPositiveException">Исключение, которое происходит, если процент от цены билета меньше нуля.</exception>
        /// <exception cref="PriceProcentHasMoreThenTwoDecimalPlacesException">Исключение, которое происходит, если в указанном проценте от цены билета более чем два знака после запятой.</exception>
        public void Validate(decimal value)
        {
            if (value < 0)
                throw new PriceProcentNonPositiveException(ExceptionMessages.PRICE_PROCENT_NON_POSITIVE, nameof(value), value);
            if (!IsValidPriceProcent(value))
                throw new PriceProcentHasMoreThenTwoDecimalPlacesException(ExceptionMessages.PRICE_PROCENT_HAS_NOT_MORE_THEN_TWO_DECIMAL_PLACES, nameof(value), value);
        }

        /// <summary>
        /// Проверка на то, сколько знаков у числа после запятой
        /// </summary>
        /// <param name="value">Десятичное значение.</param>
        /// <returns>Если разность не равна 0, возвращаем false, Если разность равна 0, возвращаем true (у числа 2 знака  после запятой)</returns>
        private bool IsValidPriceProcent(decimal value)
        {
            value = value * 100; // Умножаем value на 100
            value -= (int)value; // Вычитаем из value часть value, приведённую к целочисленному типу
            return value == 0m; // Если разность не равна 0, возвращаем false; число знаков после запятой больше двух
        }
    }
}
