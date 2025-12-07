using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Validators;

namespace TrainStation.ValueObjects
{
    /// <summary>
    /// Представляет тип денег.
    /// </summary>
    /// <param name="priceInRub">Сумма денег (в рублях).</param>
    public class Money(decimal priceInRub) : ValueObject<decimal>(
        new MoneyRubValidator(),                                  // Наследование от базовой сущности. При создании объекта класса, проверяем(валидируем) его 
        Math.Round(priceInRub, 2, MidpointRounding.AwayFromZero)) // MidpointRounding, Задает стратегию, которую математические методы округления должны использовать для округления числа.
                                                                  // AwayFromZero, - Стратегия округления до ближайшего числа, и если число находится на полпути между двумя другими, оно округляется до ближайшего числа, которое находится далеко от нуля.
    {
        // Оператор сложения для двух объектов типа Money
        public static Money operator +(Money m1, Money m2)
            => new(m1.Value + m2.Value); // Создание нового объекта, в котором результат ?

        // Оператор вычитания для двух объектов типа Money  
        public static Money operator -(Money m1, Money m2)
            => new(m1.Value - m2.Value); // Создание нового объекта, в котором результат ?

        // Оператор больше(>) для двух объектов типа Money 
        public static bool operator >(Money m1, Money m2)
            => m1.Value > m2.Value;
        // Оператор меньше(<) для двух объектов типа Money
        public static bool operator <(Money m1, Money m2)
            => m1.Value < m2.Value;

        // Оператор больше или равно (>=) для двух объектов типа Money
        public static bool operator >=(Money m1, Money m2)
            => m1.Value >= m2.Value;

        // Оператор меньше или равно (<=) для двух объектов типа Money 
        public static bool operator <=(Money m1, Money m2)
            => m1.Value <= m2.Value;
        //
        // Оператор умножения (*) объекта Money на объект PriceProcent. Результат новый объект типа Money
        public static Money operator *(Money m1, PriceProcent m2)
            => new(m1.Value * m2.Value); // Создание нового объекта, в котором результат ?
        //
        // Оператор деления (/) объекта Money на объект PriceProcent. Результат новый объект типа Money
        public static Money operator /(Money m1, PriceProcent m2)
            => new(m1.Value / m2.Value); // Создание нового объекта, в котором результат ?
    }
}
