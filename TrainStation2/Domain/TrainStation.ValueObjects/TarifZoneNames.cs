
using TrainStation.ValueObjects.Base;
using TrainStation.ValueObjects.Validators;

namespace TrainStation.ValueObjects
{
    /// <summary>
    /// Представляет тип названия тарифной зоны
    /// </summary>
    /// <param name="name">Название тарифной зоны</param>
    public class TarifZoneNames(int nameNumber) : ValueObject<int>(new TarifZoneNamesValidator(), nameNumber) // Наследование от базовой сущности. При создании объекта класса, проверяем(валидируем) его  
    {
        // Оператор сложения(+) для двух объектов типа TarifZoneNames
        public static TarifZoneNames operator +(TarifZoneNames tzn1, TarifZoneNames tzn2)
            => new(tzn1.Value + tzn2.Value);

        // Оператор вычитания(-) для двух объектов типа TarifZoneNames 
        public static TarifZoneNames operator -(TarifZoneNames tzn1, TarifZoneNames tzn2)
            => new(tzn1.Value - tzn2.Value);

        // Оператор сложения(+) для двух объектов типа TarifZoneNames и int
        public static TarifZoneNames operator +(TarifZoneNames tzn1, int val2)
            => new(tzn1.Value + val2);

        // Оператор вычитания(-) для двух объектов типа TarifZoneNames и int
        public static TarifZoneNames operator -(TarifZoneNames tzn1, int val2)
            => new(tzn1.Value - val2);

        // Оператор больше(>) для двух объектов типа TarifZoneNames 
        public static bool operator >(TarifZoneNames tzn1, TarifZoneNames tzn2)
            => tzn1.Value > tzn2.Value;

        // Оператор меньше(<) для двух объектов типа TarifZoneNames
        public static bool operator <(TarifZoneNames tzn1, TarifZoneNames tzn2)
            => tzn1.Value < tzn2.Value;

        // Оператор больше или равно (>=) для двух объектов типа TarifZoneNames
        public static bool operator >=(TarifZoneNames tzn1, TarifZoneNames tzn2)
            => tzn1.Value >= tzn2.Value;

        // Оператор меньше или равно (<=) для двух объектов типа TarifZoneNames 
        public static bool operator <=(TarifZoneNames tzn1, TarifZoneNames tzn2)
            => tzn1.Value <= tzn2.Value;

        // Оператор сравнения больше(>) для объектов типа TarifZoneNames и int
        public static bool operator >(TarifZoneNames tzn1, int val2)
            => tzn1.Value > val2;

        // Оператор сравнения меньше(<) для объектов типа TarifZoneNames и int
        public static bool operator <(TarifZoneNames tzn1, int val2)
            => tzn1.Value < val2;

        // Оператор сравнения больше или равно(>=) для объектов типа TarifZoneNames и int
        public static bool operator >=(TarifZoneNames tzn1, int val2)
            => tzn1.Value > val2;

        // Оператор сравнения меньше или равно(<=) для объектов типа TarifZoneNames и int
        public static bool operator <=(TarifZoneNames tzn1, int val2)
            => tzn1.Value < val2;
    }
}
