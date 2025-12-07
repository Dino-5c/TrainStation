
using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Exceptions;

namespace TrainStation.ValueObjects.Validators
{
    public class RoNameValidator : IValidator<string>
    {
        /// <summary>
        /// Максимальная длина названия маршрута
        /// </summary>
        public static int MAX_LENGTH => 60;

        /// <summary>
        /// Минимальная длина названия маршрута
        /// </summary>
        public static int MIN_LENGTH => 5;

        /// <summary>
        /// Проверяет строку, чтобы убедиться, что она не является нулевой, пустой и не состоит только из пробелов.
        /// </summary>
        /// <param name="value">Строка, в которой находятся данные.</param>
        /// <exception cref="ArgumentNullOrWhiteSpaceException">Исключение, которое создаётся что если,  строка нулевая или состоит из пробелов.</exception>
        /// <exception cref="RoNameLongValueException">Исключение, которое создаётся, если длина названия маршрута больше допустимой длины.</exception>
        /// <exception cref="RoNameShortValueException">Исключение, которое создаётся, если длина названия маршрута меньше допустимой длины.</exception>
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(ExceptionMessages.RO_NAME_NOT_NULL_OR_WHITE_SPACE, nameof(value)); // С помощью ключевого слова typeof мы получаем тип класса, nameof Выражение создает имя переменной, типа или элемента в виде строковой константы.
            if (value.Length > MAX_LENGTH)
                throw new RoNameLongValueException(value, MAX_LENGTH);
            if (value.Length < MIN_LENGTH)
                throw new RoNameShortValueException(value, MIN_LENGTH);
        }
    }
}
