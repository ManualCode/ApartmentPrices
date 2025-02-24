using ApartmentPrices.DataAcces.Entities;
using ApartmentPrices.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartmentPrices.DataAcces
{
    public class ApartmentPricesDbContext : DbContext
    {
        public ApartmentPricesDbContext(DbContextOptions<ApartmentPricesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApartmentSubscriptionEntity>()
                       .HasKey(e => new { e.SubscriptionId, e.ApartmentId });

            modelBuilder.Entity<ApartmentSubscriptionEntity>()
                .HasOne(e => e.Subscription)
                .WithMany(s => s.Apartments)
                .HasForeignKey(e => e.SubscriptionId);

            modelBuilder.Entity<ApartmentSubscriptionEntity>()
                .HasOne(e => e.Apartment)
                .WithMany(a => a.Subscriptions)
                .HasForeignKey(e => e.ApartmentId);
        }

        public DbSet<ApartmentEntity> Apartments { get; set; }
        public DbSet<PriceHistoryEntity> Prices { get; set; }
        public DbSet<SubscriptionEntity> Subscriptions { get; set; }

    }
}
