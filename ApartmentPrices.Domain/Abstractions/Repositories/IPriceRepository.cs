using ApartmentPrices.Domain.Models;

namespace ApartmentPrices.Domain.Abstractions.Repositories
{
    public interface IPriceRepository
    {
        Task<PriceHistory> AddAsync(PriceHistory price);
        Task<PriceHistory> UpdateAsync(PriceHistory priceHistory);
    }
}
