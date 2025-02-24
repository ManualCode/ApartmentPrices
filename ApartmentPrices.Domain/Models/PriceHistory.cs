using CSharpFunctionalExtensions;

namespace ApartmentPrices.Domain.Models
{
    public class PriceHistory
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public DateTime CheckedAt { get; set; }

        public Apartment? Apartment { get; set; }
    }
}
