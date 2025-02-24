using ApartmentPrices.DataAcces.Entities;
using ApartmentPrices.DataAcces.Mapper;
using ApartmentPrices.Domain.Abstractions.Repositories;
using ApartmentPrices.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace ApartmentPrices.DataAcces.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly ApartmentPricesDbContext dbContext;

        public ApartmentRepository(ApartmentPricesDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<Apartment> FindOrCreateAsync(Apartment apartment)
        {
            var existingApartment = await dbContext.Apartments
                .Include(x => x.Prices)
                .FirstOrDefaultAsync(a => a.Url == apartment.Url);

            if (existingApartment == null)
            {
                existingApartment = Mapping.Mapper.Map<ApartmentEntity>(apartment);
                await dbContext.Apartments.AddAsync(existingApartment);
            }

            return Mapping.Mapper.Map<Apartment>(existingApartment);
        }

        public async Task<List<Apartment>> GetAllAsync()
        {
            var apartmentsEntity = await dbContext.Apartments
                .AsNoTracking()
                .Include(x => x.Prices)
                .Include(x => x.Subscriptions)
                .ThenInclude(f => f.Subscription)
                .ToListAsync();

            var apartments = apartmentsEntity.Select(a => Mapping.Mapper.Map<Apartment>(a)).ToList();

            return apartments;

        }
    }
}
