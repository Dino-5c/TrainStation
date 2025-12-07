
namespace TrainStation.ValueObjects.Exceptions
{
    internal class FirstNameLongValueException(string firstName, int maxLength)
                : ArgumentException($"First name length {firstName} greated than maximum allowed(допустимая длина) length {maxLength}") // ArgumentException, Это исключение выбрасывается, если один из передаваемых методу аргументов является недопустимым. Наследование: Object ==> Exception ==> SystemException ==> ArgumentException
    {
        public string FirstName => firstName;
        public int MaxLength => maxLength;
    }
}
