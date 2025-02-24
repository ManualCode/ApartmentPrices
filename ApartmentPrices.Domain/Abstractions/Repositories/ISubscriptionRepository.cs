using ApartmentPrices.Domain.Models;

namespace ApartmentPrices.Domain.Abstractions.Repositories
{
    public interface ISubscribtionRepository
    {
        Task<Guid> FindOrCreateAsync(Subscription subscription);
        Task<Subscription?> GetByEmail(string email);
    }
}
