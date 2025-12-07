
using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Exceptions;

namespace TrainStation.ValueObjects.Validators
{
    /// <summary>
    /// Определяет метод, реализующий проверку десятичной дроби.
    /// </summary>
    public class MoneyRubValidator : IValidator<decimal>
    {
        /// <summary>
        /// Проверяет, что десятичная дробь не является отрицательной и не равна нулю.
        /// </summary>
        /// <param name="value">Десятичное значение.</param>
        /// <exception cref="MoneyAmountNonPositiveException">Исключение, которое происходит, если сумма денег меньше нуля.</exception>
        /// <exception cref="MoneyAmountHasMoreThenTwoDecimalPlacesException">Исключение, которое происходит, если в указанной сумме денег более чем два знака после запятой.</exception>
        public void Validate(decimal value)
        {
            if (value < 0)
                throw new MoneyAmountNonPositiveException(ExceptionMessages.MONEY_AMOUNT_NON_POSITIVE, nameof(value), value);
            if (!IsValidAmount(value))
                throw new MoneyAmountHasMoreThenTwoDecimalPlacesException(ExceptionMessages.MONEY_AMOUNT_HAS_NOT_MORE_THEN_TWO_DECIMAL_PLACES, nameof(value), value);
        }

        /// <summary>
        /// Проверка на то, сколько знаков у числа после запятой
        /// </summary>
        /// <param name="value">Десятичное значение.</param>
        /// <returns>Если разность не равна 0, возвращаем false, Если разность равна 0, возвращаем true (у числа 2 знака  после запятой)</returns>
        private bool IsValidAmount(decimal value)
        {
            value = value * 100; // Умножаем value на 100
            value -= (int)value; // Вычитаем из value часть value, приведённую к целочисленному типу
            return value == 0m; // Если разность не равна 0, возвращаем false; число знаков после запятой больше двух
        }

    }
}
