
namespace TrainStation.ValueObjects.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает, когда один из десятичных аргументов неположителен.
    /// </summary>
    /// <param name="message">Сообщение об ошибке, объясняющее причину исключения.</param>
    /// <param name="paramName">Имя параметра, вызвавшего текущее исключение.</param>
    /// <param name="value">Количество (денег в рублях).</param>
    internal class MoneyAmountNonPositiveException(string message, string paramName, decimal value)
        : ArgumentException(message, paramName) // ArgumentException, Это исключение выбрасывается, если один из передаваемых методу аргументов является недопустимым. Наследование: Object ==> Exception ==> SystemException ==> ArgumentException
    {
        public decimal Value => value;
    }
}
