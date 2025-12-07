
using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Validators;

namespace TrainStation.ValueObjects
{
    /// <summary>
    /// Представляет тип названия станции
    /// </summary>
    /// <param name="name">Название станции</param>
    public class StationName(string name) : ValueObject<string>(new StationNameValidator(), name);  // Наследование от базовой сущности. При создании объекта класса, проверяем(валидируем) его 
}
