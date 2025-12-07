
namespace TrainStation.ValueObjects.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает, когда в числе более двух десятичных знаков после запятой. 
    /// </summary>
    /// <param name="message">Сообщение об ошибке, объясняющее причину исключения.</param>
    /// <param name="paramName">Имя параметра, вызвавшего текущее исключение.</param>
    /// <param name="value">Процент (тип процента для значений нужен для умножения суммы,цены билета на число).</param>
    internal class PriceProcentHasMoreThenTwoDecimalPlacesException(string message, string paramName, decimal value)
        : ArgumentException(message, paramName) // ArgumentException, Это исключение выбрасывается, если один из передаваемых методу аргументов является недопустимым. Наследование: Object ==> Exception ==> SystemException ==> ArgumentException
    {
        public decimal Value => value;
    }
}
