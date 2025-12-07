namespace TrainStation.Domain.Entities.Base
{
    /// <summary>
    /// Представляет сущность в системе.
    /// </summary>
    /// <typeparam name="TId">Тип идентификатора сущности.</typeparam>
    /// <param name="id">Идентификатор сущности.</param>
    /// <remarks>
    /// Инициализирует новый экземпляр класса <see cref="Entity{TId}"/>.
    /// </remarks>
    public abstract class Entity<TId>(TId id) where TId : struct, IEquatable<TId>
    {
        /// <summary>
        /// Получение Id сущности
        /// </summary>
        public TId Id { get; } = id;

        /// <summary>
        /// Protected конструктор для framework сущности, если необходимо
        /// </summary>
        protected Entity() : this(default!)
        {

        }
    }
}
