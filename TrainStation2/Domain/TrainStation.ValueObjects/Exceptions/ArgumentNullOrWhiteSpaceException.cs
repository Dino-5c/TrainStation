
namespace TrainStation.ValueObjects.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает, когда один из строковых аргументов имеет значение null, пуст или состоит только из пробелов.
    /// </summary>
    /// <param name="paramName">Сообщение об ошибке, объясняющее причину исключения.</param>
    /// <param name="message">Название параметра, вызвавшего текущее исключение.</param>
    internal class ArgumentNullOrWhiteSpaceException(string paramName, string message) // Наследуемся от класса ArgumentNullException
        : ArgumentNullException(paramName, message);
    // Исключение ArgumentNullException возникает
    // при вызове метода и по крайней мере один из переданных аргументов имеет значение null , но никогда не должно
    // иметь значение null.
}
