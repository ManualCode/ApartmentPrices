using ApartmentPrices.Domain.Models;

namespace ApartmentPrices.Domain.Abstractions.Services
{
    public interface ISubscriptionService
    {
        Task<Guid> CreateSubscribtion(string email, string url);

        Task<Subscription?> GetSubscribtion(string email);
    }
}
