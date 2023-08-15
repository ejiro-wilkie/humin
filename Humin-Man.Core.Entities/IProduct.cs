using System;
using System.Collections.Generic;
using System.Text;

namespace Humin_Man.Core.Entities
{
    /// <summary>
    /// Interface that defines the product service.
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
        /// Gets or sets the image URL or path for the product.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        string Image { get; set; }

        /// <summary>
        /// Gets or sets the buy price of the product.
        /// </summary>
        /// <value>
        /// The buy price.
        /// </value>
        decimal BuyPrice { get; set; }

        /// <summary>
        /// Gets or sets the sell price of the product.
        /// </summary>
        /// <value>
        /// The sell price.
        /// </value>
        decimal SellPrice { get; set; }

        /// <summary>
        /// Gets or sets the category identifier which the product belongs to.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        long CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        ICategory Category{ get; set; }

    }
}
