using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Exceptions;

namespace TrainStation.ValueObjects.Validators
{
    public class LastNameValidator : IValidator<string>
    {
        /// <summary>
        /// Максимальная длина фамилии
        /// </summary>
        public static int MAX_LENGTH => 50;
        /// <summary>
        /// Минимальная длина фамилии
        /// </summary>
        public static int MIN_LENGTH => 2;

        /// <summary>
        /// Проверяет строку, чтобы убедиться, что она не является нулевой, пустой и не состоит только из пробелов.
        /// </summary>
        /// <param name="value">Строка, в которой находятся данные.</param>
        /// <exception cref="ArgumentNullOrWhiteSpaceException">Исключение, которое создаётся что если,  строка нулевая или состоит из пробелов.</exception>
        /// <exception cref="LastNameLongValueException">Исключение, которое создаётся, если длина фамилии больше допустимой длины.</exception>
        /// <exception cref="LastNameShortValueException">Исключение, которое создаётся, если длина фамилии меньше допустимой длины.</exception>
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(ExceptionMessages.LASTNAME_NOT_NULL_OR_WHITE_SPACE, nameof(value)); // С помощью ключевого слова typeof мы получаем тип класса
            if (value.Length > MAX_LENGTH)
                throw new LastNameLongValueException(value, MAX_LENGTH);
            if (value.Length < MIN_LENGTH)
                throw new LastNameShortValueException(value, MIN_LENGTH);
        }

    }
}
