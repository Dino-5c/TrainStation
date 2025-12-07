
namespace TrainStation.ValueObjects.Exceptions
{
    internal class RoNameLongValueException(string routeName, int maxLength)
        : ArgumentException($"Route name length {routeName} greated than maximum allowed length (допустимая длина) {maxLength}") // Было FormatException. Исключение, которое возникает в случае, если формат аргумента недопустим или строка составного формата построена неправильно. Наследование  Object ==> Exception ==> SystemException ==> FormatException
    // ArgumentException, Это исключение выбрасывается, если один из передаваемых методу аргументов является недопустимым.Наследование: Object ==> Exception ==> SystemException ==> ArgumentException
    {
        public string RoName => routeName;
        public int MaxLength => maxLength;
    }
}
