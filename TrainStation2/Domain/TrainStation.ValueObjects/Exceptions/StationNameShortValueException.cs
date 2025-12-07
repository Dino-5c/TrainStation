
namespace TrainStation.ValueObjects.Exceptions
{
    internal class StationNameShortValueException(string stationName, int minLength)
         : ArgumentException($"Station name length {stationName} less than minimum allowed length (допустимая длина) {minLength}") // Было FormatException. Исключение, которое возникает в случае, если формат аргумента недопустим или строка составного формата построена неправильно.  Наследование  Object ==> Exception ==> SystemException ==> FormatException
    // ArgumentException, Это исключение выбрасывается, если один из передаваемых методу аргументов является недопустимым. Наследование: Object ==> Exception ==> SystemException ==> ArgumentException
    {
        public string StationName => stationName;
        public int MinLength => minLength;
    }
}
