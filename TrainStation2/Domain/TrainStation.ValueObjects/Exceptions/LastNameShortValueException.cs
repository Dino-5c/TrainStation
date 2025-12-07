
namespace TrainStation.ValueObjects.Exceptions
{
    internal class LastNameShortValueException(string lastName, int minLength)
        : ArgumentException($"Last name length {lastName} less than minimum allowed(допустимая длина) length {minLength}") // ArgumentException, Это исключение выбрасывается, если один из
                                                                                                                           // передаваемых методу аргументов является недопустимым. Наследование: Object ==> Exception ==> SystemException ==> ArgumentException
    {
        public string LastName => lastName;
        public int MinLength => minLength;
    }
}
