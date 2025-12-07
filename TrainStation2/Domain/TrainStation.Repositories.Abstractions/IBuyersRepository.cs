
using TrainStation.Domain.Entities;

namespace TrainStation.Repositories.Abstractions
{
    public interface IBuyersRepository : IRepository<Buyer, Guid>
    {
        Task<Buyer?> GetBuyerByLastNameAsync(string lastName, CancellationToken cancellationToken);
    }
}
