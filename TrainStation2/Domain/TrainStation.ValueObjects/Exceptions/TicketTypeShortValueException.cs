
namespace TrainStation.ValueObjects.Exceptions
{
    internal class TicketTypeShortValueException(string ticketTypeName, int minLength)
        : ArgumentException($"Type of Ticket name length {ticketTypeName} less than minimum allowed length (допустимая длина) {minLength}") // ArgumentException, Это исключение выбрасывается, если один из передаваемых методу аргументов является недопустимым. Наследование: Object ==> Exception ==> SystemException ==> ArgumentException
    {
        public string TicketTypeName => ticketTypeName;
        public int MinLength => minLength;
    }
}
