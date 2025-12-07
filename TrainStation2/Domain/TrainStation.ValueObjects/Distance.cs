
using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Validators;

namespace TrainStation.ValueObjects
{
    /// <summary>
    /// Представляет тип расстояния.
    /// </summary>
    /// <param name="distance">Расстояние</param>
    public class Distance(int distance) : ValueObject<int>(new DistanceValidator(), distance) // Наследование от базовой сущности. При создании объекта класса, проверяем(валидируем) его 
    {
        // Оператор сложения для двух объектов типа Distance
        public static Distance operator +(Distance d1, Distance d2)
            => new(d1.Value + d2.Value);

        // Оператор вычитания для двух объектов типа Distance
        public static Distance operator -(Distance d1, Distance d2)
            => new(d1.Value - d2.Value);

        // Оператор больше(>) для двух объектов типа Distance
        public static bool operator >(Distance d1, Distance d2)
            => d1.Value > d2.Value;

        // Оператор меньше(<) для двух объектов типа Distance
        public static bool operator <(Distance d1, Distance d2)
            => d1.Value < d2.Value;

        // Оператор больше или равно (>=) для двух объектов типа Distance
        public static bool operator >=(Distance d1, Distance d2)
            => d1.Value >= d2.Value;

        // Оператор меньше или равно (<=) для двух объектов типа Distance
        public static bool operator <=(Distance d1, Distance d2)
            => d1.Value <= d2.Value;
    }
}
