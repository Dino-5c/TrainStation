
namespace TrainStation.ValueObjects.Exceptions
{
    internal class FirstNameShortValueException(string firstName, int minLength)
               : ArgumentException($"First name length {firstName} less than minimum allowed(допустимая длина) length {minLength}") // ArgumentException, Это исключение выбрасывается, если один из передаваемых методу аргументов является недопустимым. Наследование: Object ==> Exception ==> SystemException ==> ArgumentException
    {
        public string FirstName => firstName;
        public int MinLength => minLength;
    }
}
