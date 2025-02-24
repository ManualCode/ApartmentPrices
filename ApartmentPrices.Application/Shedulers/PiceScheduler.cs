using ApartmentPrices.Application.Services;
using ApartmentPrices.Domain.Abstractions.Repositories;
using ApartmentPrices.Domain.Abstractions.Services;
using ApartmentPrices.Domain.Models;
using Quartz;

namespace ApartmentPrices.Application.Shedulers
{
    public class PiceScheduler : IJob
    {
        private readonly IApartmentRepository apartmentRepository;
        private readonly IPriceRepository priceRepository;
        private readonly IWebParsingService webParsingService;

        public PiceScheduler(IApartmentRepository apartmentRepository, IPriceRepository priceRepository,
             IWebParsingService webParsingService)
        {
            this.apartmentRepository = apartmentRepository;
            this.priceRepository = priceRepository;
            this.webParsingService = webParsingService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            foreach (var apartment in await apartmentRepository.GetAllAsync())
            {
                var latestPrice = apartment.Prices.OrderByDescending(x => x.CheckedAt).FirstOrDefault();
                var actualPrice = await webParsingService.GetPriceByUrl(apartment.Url);

                if (latestPrice.Price == actualPrice) continue;

                var newPrice = new PriceHistory { Id = Guid.NewGuid(), Price = actualPrice, CheckedAt = DateTime.UtcNow, Apartment = apartment };

                var price = await priceRepository.UpdateAsync(newPrice);

                var emails = apartment.Subscriptions.Select(x => x.Email).ToList();
                foreach (var email in emails)
                {
                    var message = $"Цена на квартиру ({apartment.Url}), находящуюся по адресу {apartment.Address}," +
                        $" изменилась и теперь составвляет: {price.Price} рублей.";
                    await EmailService.SendEmailAsync(email, "Цена изменилась", message);
                }
            }

        }
    }
}
