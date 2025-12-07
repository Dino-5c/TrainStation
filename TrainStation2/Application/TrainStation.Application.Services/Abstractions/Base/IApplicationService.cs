
using TrainStation.Application.Models.Base;

namespace TrainStation.Application.Services.Abstractions.Base
{
    public interface IApplicationService<TModel, TCreateModel, in TId>
        where TModel : IModel<TId>
        where TId : struct, IEquatable<TId>
        where TCreateModel : ICreateModel
    {
        Task<TModel?> GetModelByIdAsync(TId id, CancellationToken cancellationToken = default);
        Task<IEquatable<TModel>> GetModelsAsync(CancellationToken cancellationToken = default);
        Task<TModel?> CreateModelAsync(TCreateModel model, CancellationToken cancellationToken = default);
        Task<bool> UpdateModelAsync(TModel model, CancellationToken cancellationToken = default);
        Task<bool> DeleteModelAsync(TId id, CancellationToken cancellationToken = default);
    }
}
