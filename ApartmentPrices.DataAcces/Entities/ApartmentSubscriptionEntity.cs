using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApartmentPrices.DataAcces.Entities
{
    public class ApartmentSubscriptionEntity
    {
        
        public Guid SubscriptionId { get; set; }

        public SubscriptionEntity Subscription { get; set; }
        
        public Guid ApartmentId { get; set; }

        public ApartmentEntity Apartment { get; set; }
    }
}
