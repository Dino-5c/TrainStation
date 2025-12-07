
using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Validators;

namespace TrainStation.ValueObjects
{
    /// <summary>
    /// Представляет тип названия маршрута
    /// </summary>
    /// <param name="name">Название маршрута</param>
    public class RoName(string name) : ValueObject<string>(new RoNameValidator(), name); // Наследование от базовой сущности. При создании объекта класса, проверяем(валидируем) его 
}
