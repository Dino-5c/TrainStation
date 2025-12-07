using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStation.ValueObjects.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает, когда аргумент не положителен
    /// </summary>
    /// <param name="message">Сообщение об ошибке, объясняющее причину исключения.</param>
    /// <param name="paramName">Имя параметра, вызвавшего текущее исключение.</param>
    /// <param name="value">Расстояние</param>
    internal class DistanceNonPositiveException(string message, string paramName, int value)
                : ArgumentException(message, paramName) // ArgumentException, Это исключение выбрасывается, если один из передаваемых методу аргументов является недопустимым. Наследование: Object ==> Exception ==> SystemException ==> ArgumentException
    {
        public int Value => value;
    }
}
