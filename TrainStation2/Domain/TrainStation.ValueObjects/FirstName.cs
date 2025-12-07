
using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Validators;

namespace TrainStation.ValueObjects
{
    /// <summary>
    /// Представляет тип имени сущности (покупателя, администратора и т. д.).
    /// </summary>
    /// <param name="name">Имя сущности.</param>
    public class FirstName(string name) : ValueObject<string>(new FirstNameValidator(), name); // Наследование от базовой сущности. При создании объекта класса, проверяем(валидируем) его 
}
