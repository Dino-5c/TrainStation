
namespace TrainStation.ValueObjects.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает, если для типа не указан метод проверки.
    /// </summary>
    /// <param name="paramName">Имя типа объекта, в котором произошло текущее исключение.</param>
    /// <param name="message">Сообщение об ошибке, объясняющее причину исключения.</param>
    internal class ValidatorNullException(string paramName, string message) // Наследуемся от класса ArgumentNullException
        : ArgumentNullException(paramName, message); // ArgumentNullException Исключение, которое создается при передаче пустой ссылки методу, который не принимает ее как допустимый аргумент.
    // Исключение ArgumentNullException возникает
    // при вызове метода и по крайней мере один из переданных аргументов имеет значение null , но никогда не должно
    // иметь значение null.
}
