
using TrainStation.Domain.Entities;

namespace TrainStation.Repositories.Abstractions
{
    public interface IAdministratorsRepository : IRepository<Administrator, Guid>
    {
        Task<Administrator?> GetAdministratorByLastNameAsync(string lastName, CancellationToken cancellationToken);
    }
}
