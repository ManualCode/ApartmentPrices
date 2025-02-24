using ApartmentPrices.DataAcces.Entities;
using ApartmentPrices.DataAcces.Mapper;
using ApartmentPrices.Domain.Abstractions.Repositories;
using ApartmentPrices.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartmentPrices.DataAcces.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        private readonly ApartmentPricesDbContext dbContext;

        public PriceRepository(ApartmentPricesDbContext dbContext)
           => this.dbContext = dbContext;

        public async Task<PriceHistory> UpdateAsync(PriceHistory priceHistory)
        {
            if (dbContext.Prices.Where(x => x.ApartmentId == priceHistory.Apartment.Id).Count() >= 5)
            {
                var priceToDelete = await dbContext.Prices
                    .Where(x => x.ApartmentId == priceHistory.Apartment.Id)
                    .OrderBy(x => x.CheckedAt)
                    .FirstOrDefaultAsync();
                dbContext.Prices.Remove(priceToDelete);
            }

            var priceEntity = Mapping.Mapper.Map<PriceHistoryEntity>(priceHistory);

            await dbContext.Prices.AddAsync(priceEntity);
            await dbContext.SaveChangesAsync();

            return Mapping.Mapper.Map<PriceHistory>(priceEntity);
        }


        public async Task<PriceHistory> AddAsync(PriceHistory price)
        {
            var existingPrice = await dbContext.Prices
                .Where(x => x.ApartmentId == price.Apartment.Id)
                .OrderByDescending(x => x.CheckedAt)
                .FirstOrDefaultAsync();

            if (existingPrice == null)
            {
                await dbContext.Prices.AddAsync(Mapping.Mapper.Map<PriceHistoryEntity>(price));
                await dbContext.SaveChangesAsync();
            }

            return Mapping.Mapper.Map<PriceHistory>(existingPrice);

        }

    }
}
