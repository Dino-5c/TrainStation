
using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Exceptions;

namespace TrainStation.ValueObjects.Validators
{
    public class DistanceValidator : IValidator<int>
    {
        /// <summary>
        /// Проверяет, что число не может быть меньше, чем 0.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <exception cref="DistanceNonPositiveException">Исключение, которое происходит, если расстояние меньше нуля.</exception>
        public void Validate(int value)
        {
            if (value < 0)
                throw new DistanceNonPositiveException(ExceptionMessages.DISTANCE_NON_POSITIVE, nameof(value), value);
        }
    }
}
