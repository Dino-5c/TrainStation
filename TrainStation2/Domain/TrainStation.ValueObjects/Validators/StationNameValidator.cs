
using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Exceptions;

namespace TrainStation.ValueObjects.Validators
{
    public class StationNameValidator : IValidator<string>
    {
        /// <summary>
        /// Максимальная длина названия станции
        /// </summary>
        public static int MAX_LENGTH => 90;
        /// <summary>
        /// Минимальная длина названия станции
        /// </summary>
        public static int MIN_LENGTH => 3;
        /// <summary>
        /// Проверяет строку, чтобы убедиться, что она не является нулевой, пустой и не состоит только из пробелов.
        /// </summary>
        /// <param name="value">Строка, в которой находятся данные.</param>
        /// <exception cref="ArgumentNullOrWhiteSpaceException">Исключение, которое создаётся если, строка нулевая или состоит из пробелов.</exception>
        /// <exception cref="StationNameLongValueException">Исключение, которое создаётся, если длина названия станции больше допустимой длины.</exception>
        /// <exception cref="StationNameShortValueException">Исключение, которое создаётся, если длина названия станции меньше допустимой длины.</exception>
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(ExceptionMessages.STATION_NAME_NOT_NULL_OR_WHITE_SPACE, nameof(value)); // С помощью ключевого слова typeof мы получаем тип класса. Nameof Выражение создает имя переменной, типа или элемента в виде строковой константы.
            if (value.Length > MAX_LENGTH)
                throw new StationNameLongValueException(value, MAX_LENGTH);
            if (value.Length < MIN_LENGTH)
                throw new StationNameShortValueException(value, MIN_LENGTH);
        }


    }
}
