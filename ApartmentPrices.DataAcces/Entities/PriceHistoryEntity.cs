using System.ComponentModel.DataAnnotations;

namespace ApartmentPrices.DataAcces.Entities
{
    public class PriceHistoryEntity
    {
        /// <summary>
        /// Идентификатор цены.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Дата последнего обновления цены.
        /// </summary>
        public DateTime CheckedAt { get; set; }

        /// <summary>
        /// Идентификатор квартиры.
        /// </summary>
        public Guid ApartmentId { get; set; }

        /// <summary>
        /// Квартира, к которой привязана цена.
        /// </summary>
        public ApartmentEntity? Apartment { get; set; }
    }
}
