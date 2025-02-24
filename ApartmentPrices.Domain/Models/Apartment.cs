using CSharpFunctionalExtensions;

namespace ApartmentPrices.Domain.Models
{
    public class Apartment
    {
        public Guid Id { get; set; }

        public string Url { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public List<PriceHistory> Prices { get; set; } = [];

        public List<Subscription> Subscriptions { get; set; } = [];
    }
}
