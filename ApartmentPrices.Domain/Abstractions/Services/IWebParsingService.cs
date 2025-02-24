using ApartmentPrices.Domain.Models;

namespace ApartmentPrices.Domain.Abstractions.Services
{
    public interface IWebParsingService
    {
        Task<decimal> GetPriceByUrl(string url);

        Task<string> GetStatusByUrl(string url);

        Task<(string Address, decimal Price, string Status)> GetInfo(string url);
    }
}
