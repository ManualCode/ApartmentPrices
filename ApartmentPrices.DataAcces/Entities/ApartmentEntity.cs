using System.ComponentModel.DataAnnotations;


namespace ApartmentPrices.DataAcces.Entities
{
    public class ApartmentEntity
    {
        /// <summary>
        /// Идентификатор квартиры.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Ссылка на квартиру.
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Статус, в котором сейчас находиться квартира.
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Адрес, по которому находиться квартира.
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Цена.
        /// </summary>
        public List<PriceHistoryEntity> Prices { get; set; } = [];

        /// <summary>
        /// Договоры.
        /// </summary>

        public List<ApartmentSubscriptionEntity> Subscriptions { get; set; } = [];


    }
}
