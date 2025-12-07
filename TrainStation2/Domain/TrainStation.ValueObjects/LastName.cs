using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Validators;

namespace TrainStation.ValueObjects
{
    /// <summary>
    /// Представляет тип фамилии сущности (покупателя, администратора и т. д.).
    /// </summary>
    /// <param name="name">Фамилия сущности.</param>
    public class LastName(string name) : ValueObject<string>(new LastNameValidator(), name); // Наследование от базовой сущности. При создании объекта класса, проверяем(валидируем) его 
}
