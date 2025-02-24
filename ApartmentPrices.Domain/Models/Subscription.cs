using CSharpFunctionalExtensions;

namespace ApartmentPrices.Domain.Models
{
    public class Subscription
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public List<Apartment> Apartments { get; set; } = [];
    }
}
