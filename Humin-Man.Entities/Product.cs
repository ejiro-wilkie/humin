using Humin_Man.Core.Entities;

namespace Humin_Man.Entities
{
    /// <summary>
    /// Class that represents the product entity.
    /// </summary>
    /// <seealso cref="Humin_Man.Entities.BaseEnetity" />
    public class Product : BaseEnetity, IProduct
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the category
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public virtual ICategory Category { get; set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public long CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the buy price.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public decimal BuyPrice { get; set; }

        /// <summary>
        /// Gets or sets the sell price
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public decimal SellPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        /// <value>
        /// The quantity
        /// </value>
        public long Quantity { get; set; }
    }
}
