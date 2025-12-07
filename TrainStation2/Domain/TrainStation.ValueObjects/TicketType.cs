using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Validators;

namespace TrainStation.ValueObjects
{
    /// <summary>
    /// Представляет тип названия типа билета
    /// </summary>
    /// <param name="ticketType">Название типа билета</param>
    public class TicketType(string ticketType) : ValueObject<string>(new TicketTypeValidator(), ticketType); // Наследование от базовой сущности. При создании объекта класса, проверяем(валидируем) его 
}
