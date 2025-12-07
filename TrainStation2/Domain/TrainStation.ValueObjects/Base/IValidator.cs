
namespace TrainStation.ValueObjects.Base
{
    /// <summary>
    /// Определяет метод, реализующий проверку объекта.
    /// </summary>
    /// <typeparam name="T">Тип проверяемого объекта</typeparam>
    public interface IValidator<T>
    {
        /// <summary>
        /// Проверяет данные.
        /// </summary>
        /// <param name="value">Проверенное значение</param>
        void Validate(T value);
    }
}
