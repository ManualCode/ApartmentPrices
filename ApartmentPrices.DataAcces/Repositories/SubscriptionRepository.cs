using ApartmentPrices.DataAcces.Entities;
using ApartmentPrices.DataAcces.Mapper;
using ApartmentPrices.Domain.Abstractions.Repositories;
using ApartmentPrices.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace ApartmentPrices.DataAcces.Repositories
{
    public class SubscriptionRepository: ISubscribtionRepository
    {
        private readonly ApartmentPricesDbContext dbContext;

        public SubscriptionRepository(ApartmentPricesDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<Guid> FindOrCreateAsync(Subscription subscription)
        {
            var existingSubscription = await dbContext.Subscriptions.Include(x => x.Apartments).FirstOrDefaultAsync(s => s.Email == subscription.Email);

            if (existingSubscription == null)
            {
                existingSubscription = Mapping.Mapper.Map<SubscriptionEntity>(subscription);
                await dbContext.Subscriptions.AddAsync(existingSubscription);
            }

            if (existingSubscription.Apartments.Any(a => a.ApartmentId == subscription.Apartments[0].Id))
                throw new InvalidOperationException("Вы уже подписаны на эту квартиру.\n");

            existingSubscription.Apartments.Add(new ApartmentSubscriptionEntity { SubscriptionId = existingSubscription.Id, ApartmentId = subscription.Apartments[0].Id });
            await dbContext.SaveChangesAsync();

            return existingSubscription.Id;
        }

        public async Task<Subscription?> GetByEmail(string email)
        {
            var subsriptionEntity = await dbContext.Subscriptions
                .AsNoTracking()
                .Where(s => s.Email == email)
                .Include(s => s.Apartments)
                .ThenInclude(x => x.Apartment)
                .ThenInclude(x => x.Prices)
                .FirstOrDefaultAsync();

            if (subsriptionEntity == null) return null;

            return Mapping.Mapper.Map<Subscription>(subsriptionEntity);
        }
    }
}
