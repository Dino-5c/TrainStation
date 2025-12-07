
namespace TrainStation.ValueObjects.Exceptions
{
    internal class LastNameLongValueException(string lastName, int maxLength)
        : ArgumentException($"Last name length {lastName} greated than maximum allowed(допустимая длина) length {maxLength}") // ArgumentException, Это исключение выбрасывается, если один из передаваемых
                                                                                                                              // методу аргументов является недопустимым. Наследование: Object ==> Exception ==> SystemException ==> ArgumentException
    {
        public string LastName => lastName;
        public int MaxLength => maxLength;
    }
}
