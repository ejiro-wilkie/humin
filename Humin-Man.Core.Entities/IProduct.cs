using System;
using System.Collections.Generic;
using System.Text;

namespace Humin_Man.Core.Entities
{
    /// <summary>
    /// Class that represents the shop
    /// </summary>
    public interface IProduct : IBaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        string Image { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        ICategory Category { get; set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        long CategoryId { get; set; }

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
