using ApartmentPrices.Domain.Abstractions.Repositories;
using ApartmentPrices.Domain.Abstractions.Services;
using ApartmentPrices.Domain.Models;


namespace ApartmentPrices.Application.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscribtionRepository subscriptionRepository;
        private readonly IPriceRepository priceRepository;
        private readonly IApartmentRepository apartmentRepository;
        private readonly IWebParsingService webParsingService;

        public SubscriptionService(ISubscribtionRepository subscriptionRepository, IPriceRepository priceRepository,
            IApartmentRepository apartmentRepository, IWebParsingService webParsingService)
        {
            this.subscriptionRepository = subscriptionRepository;
            this.priceRepository = priceRepository;
            this.apartmentRepository = apartmentRepository;
            this.webParsingService = webParsingService;
        }

        public async Task<Guid> CreateSubscribtion(string email, string url)
        {

            var apartmentInfo = await webParsingService.GetInfo(url);
            var apartment = await apartmentRepository.FindOrCreateAsync(new Apartment
            {
                Id = Guid.NewGuid(),
                Url = url,
                Status = apartmentInfo.Status,
                Address = apartmentInfo.Address
            });

            var priceHistory = await priceRepository.AddAsync(new PriceHistory
            {
                Id = Guid.NewGuid(),
                Price = apartmentInfo.Price,
                CheckedAt = DateTime.UtcNow,
                Apartment = apartment
            });

            var s = new Subscription { Id = Guid.NewGuid(), Email = email, CreatedAt = DateTime.UtcNow, Apartments = new List<Apartment> { apartment } };
            var subscriptionGuid = await subscriptionRepository.FindOrCreateAsync(s);

            return subscriptionGuid;
        }

        public async Task<Subscription?> GetSubscribtion(string email)
            => await subscriptionRepository.GetByEmail(email);
    }
}
