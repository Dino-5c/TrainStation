using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Validators;

namespace TrainStation.ValueObjects
{
    /// <summary>
    /// Представляет тип процента от цены билета
    /// </summary>
    /// <param name="priceProcent">Процент от цены билета</param>
    public class PriceProcent(decimal priceProcent) : ValueObject<decimal>(
        new PriceProcentValidator(),
               Math.Round(priceProcent, 2, MidpointRounding.AwayFromZero)) // MidpointRounding, Задает стратегию, которую математические методы округления должны использовать для округления числа.
                                                                           // AwayFromZero, - Стратегия округления до ближайшего числа, и если число находится на полпути между двумя другими, оно округляется до ближайшего числа, которое находится далеко от нуля.)
    {
        // Оператор сложения(+) для двух объектов типа PriceProcent
        public static PriceProcent operator +(PriceProcent p1, PriceProcent p2)
            => new(p1.Value + p2.Value);

        // Оператор вычитания(-) для двух объектов типа PriceProcent
        public static PriceProcent operator -(PriceProcent p1, PriceProcent p2)
            => new(p1.Value - p2.Value);

        // Оператор больше(>) для двух объектов типа PriceProcent 
        public static bool operator >(PriceProcent m1, PriceProcent m2)
            => m1.Value > m2.Value;

        // Оператор меньше(<) для двух объектов типа PriceProcent
        public static bool operator <(PriceProcent m1, PriceProcent m2)
            => m1.Value < m2.Value;

        // Оператор больше или равно (>=) для двух объектов типа PriceProcent
        public static bool operator >=(PriceProcent m1, PriceProcent m2)
            => m1.Value >= m2.Value;

        // Оператор меньше или равно (<=) для двух объектов типа PriceProcent 
        public static bool operator <=(PriceProcent m1, PriceProcent m2)
            => m1.Value <= m2.Value;

        //
        // Оператор умножения (*) двух объектов PriceProcent. Результат новый объект типа PriceProcent
        public static PriceProcent operator *(PriceProcent m1, PriceProcent m2)
            => new(m1.Value * m2.Value); // Создание нового объекта, в котором результат ?

        //
        // Оператор деления (/) двух объектов PriceProcent. Результат новый объект типа PriceProcent
        public static PriceProcent operator /(PriceProcent m1, PriceProcent m2)
            => new(m1.Value / m2.Value); // Создание нового объекта, в котором результат ?

        // Оператор умножения (*) объектов типа  PriceProcent и int. Результат новый объект типа PriceProcent
        public static PriceProcent operator *(PriceProcent m1, int m2)
            => new(m1.Value * m2); // Создание нового объекта, в котором результат ?

        // Оператор деления (/) объектов PriceProcent и int. Результат новый объект типа PriceProcent
        public static PriceProcent operator /(PriceProcent m1, int m2)
            => new(m1.Value / m2); // Создание нового объекта, в котором результат ?

        // Оператор умножения (*) объектов типа  PriceProcent и decimal. Результат новый объект типа PriceProcent
        public static PriceProcent operator *(PriceProcent m1, decimal m2)
            => new(m1.Value * m2); // Создание нового объекта, в котором результат ?

        // Оператор деления (/) объектов PriceProcent и decimal. Результат новый объект типа PriceProcent
        public static PriceProcent operator /(PriceProcent m1, decimal m2)
            => new(m1.Value / m2); // Создание нового объекта, в котором результат ?
    }
}
