using System.ComponentModel.DataAnnotations;


namespace ApartmentPrices.DataAcces.Entities
{
    public class SubscriptionEntity
    {
        /// <summary>
        /// Идентификатор подписки.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Почта, по которой необходимо присылать изменения.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Дата создания подписки.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Список квартир, у которых необходимо отслеживать изменение цен.
        /// </summary>
        public List<ApartmentSubscriptionEntity> Apartments { get; set; } = [];
    }
}
