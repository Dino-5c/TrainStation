using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Exceptions;

namespace TrainStation.ValueObjects.Validators
{
    public class TicketTypeValidator : IValidator<string>
    {
        /// <summary>
        /// Максимальная длина названия типа билета
        /// </summary>
        public static int MAX_LENGTH => 20;

        /// <summary>
        /// Минимальная длина названия типа билета
        /// </summary>
        public static int MIN_LENGTH => 5;

        /// <summary>
        /// Проверяет строку, чтобы убедиться, что она не является нулевой, пустой и не состоит только из пробелов.
        /// </summary>
        /// <param name="value">Строка, в которой находятся данные.</param>
        /// <exception cref="ArgumentNullOrWhiteSpaceException">Исключение, которое создаётся если, строка нулевая или состоит из пробелов.</exception>
        /// <exception cref="TicketTypeLongValueException">Исключение, которое создаётся, если длина названия типа билета больше допустимой длины.</exception>
        /// <exception cref="TicketTypeShortValueException">Исключение, которое создаётся, если длина названия типа билета меньше допустимой длины.</exception>
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(ExceptionMessages.TICKET_TYPE_NOT_NULL_OR_WHITE_SPACE, nameof(value)); // С помощью ключевого слова typeof мы получаем тип класса. Nameof Выражение создает имя переменной, типа или элемента в виде строковой константы.
            if (value.Length > MAX_LENGTH)
                throw new TicketTypeLongValueException(value, MAX_LENGTH);
            if (value.Length < MIN_LENGTH)
                throw new TicketTypeShortValueException(value, MIN_LENGTH);
        }
    }
}
