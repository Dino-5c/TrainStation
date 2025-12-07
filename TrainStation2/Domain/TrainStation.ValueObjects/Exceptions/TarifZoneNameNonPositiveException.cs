
namespace TrainStation.ValueObjects.Exceptions
{
    /// <summary>
    /// Исключение, которое происходит, если омер тарифной зоны меньше допустимого значения - нуля
    /// </summary>
    /// <param name="message">Сообщение об ошибке, объясняющее причину исключения.</param>
    /// <param name="paramName">Имя параметра, вызвавшего текущее исключение.</param>
    /// <param name="value">Номер-название тарифной зоны.</param>
    internal class TarifZoneNameNonPositiveException(string message, string paramName, int value)
        : ArgumentException(message, paramName) // ArgumentException, Это исключение выбрасывается, если один из передаваемых методу аргументов является недопустимым. Наследование: Object ==> Exception ==> SystemException ==> ArgumentException
    {
        public int Value => value;
    }
}
