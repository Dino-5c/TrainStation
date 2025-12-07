

using TrainStation.ValueObjects.Exceptions;

namespace TrainStation.ValueObjects.Base
{
    public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
    {
        // IEquatable Определяет обобщенный метод, реализующий тип значения или класс для создания метода для определения равенства экземпляров.

        public T Value { get; }
        // Проверка значения определённым валидатором, когда создаём объект, проверяем его на правильность, указанную при проверки данного (этого) (типа), класса
        protected ValueObject(IValidator<T> validator, T value)
        {
            if (validator == null)
                throw new ValidatorNullException(GetType().Name ?? String.Empty, ExceptionMessages.VALIDATOR_MUST_BE_SPECIFIED); // GetType().Name ?? String.Empty - имя типа объекта,ExceptionMessages.VALIDATOR_MUST_BE_SPECIFIED - сообщение об ошибке, объясняющее это исключение
            validator.Validate(value);
            Value = value;
        }

        /// <summary>
        /// Метод ToString служит для получения строкового представления данного объекта.
        /// </summary>
        /// <returns>Оператор объединения с null ?? возвращает значение левого операнда, если оно не равно null; в противном случае он вычисляет правый операнд и возвращает его значение.</returns>
        public override string ToString()
            => Value!.ToString() ?? GetType().ToString();
        // Оператор объединения с null ?? возвращает значение левого операнда, если оно не равно null;
        // в противном случае он вычисляет правый операнд и возвращает его значение.
        // Оператор ?? не вычисляет правый операнд, если левый операнд равен ненулевому значению. Оператор присваивания null-объединения присваивает
        // значение правого операнда левому операнду только
        // в том случае, если левый операнд оценивается как null.


        /// <summary>
        /// Хэш-функция используется для быстрого создания числа (хэш-кода), соответствующего значению объекта . 
        /// </summary>
        /// <returns>Хэш-код объекта</returns>
        public override int GetHashCode()
            => Value!.GetHashCode();

        /// <summary>
        /// Метод Equals позволяет сравнить два объекта на равенство. В качестве параметра 
        /// он принимает объект для сравнения в виде типа object и возврашает
        /// true, если оба объекта равны:
        /// </summary>
        /// <param name="other">объект для сравнения</param>
        /// <returns>Возвращается true, если оба объекта равны</returns>
        public override bool Equals(object? other) // Переопределённый метод Equals (override bool)
            => Equals(other as ValueObject<T>);

        public bool Equals(ValueObject<T>? other)
        {
            // Если object равен null
            if (other == null)
                return false; // Возвращается false
            // Если данный объект и переданный объект один экземпляр,
            if (ReferenceEquals(this, other)) // Определяет, являются ли указанные экземпляры объекта одним и тем же экземпляром.
                return true; // Возвращается true
            // Если тип объекта не равен типу данного объекта,
            if (GetType() != other.GetType()) // Метод GetType позволяет получить тип данного объекта.
                return false; // Возвращаем false
            return other.Value!.Equals(Value); // Возвращается результат, эквивалентны, равны ли объекты
        }

        /// <summary>
        /// Оператор == сравнения
        /// </summary>
        /// <param name="left">Первое(слева) значение</param>
        /// <param name="right">Второе(справа) значение</param>
        /// <returns>Результат, эквивалентны значения или нет</returns>
        public static bool operator ==(ValueObject<T>? left, ValueObject<T>? right)
            => Equals(left, right);


        /// <summary>
        /// != Оператор  неравенства
        /// </summary>
        /// <param name="left">Первое(слева) значение</param>
        /// <param name="right">Второе(справа) значение</param>
        /// <returns>Возвращается неравенство значений первого и второго</returns>
        public static bool operator !=(ValueObject<T>? left, ValueObject<T>? right)
            => !(left == right);
    }
}
