using System;
using Humin_Man.ViewModels.Category;

namespace Humin_Man.ViewModels.Product
{
    /// <summary>
    /// Class that represents the add product view model.
    /// </summary>
    public class ProductViewModel
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public long Id { get; set; }

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
        /// Gets or sets the category id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public long CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The capacity.
        /// </value>
        public CategoryViewModel Category { get; set; }

        /// <summary>
        /// Gets or sets a value indicating when this instance was last updated.
        /// </summary>
        /// <value>
        /// The datetime.
        /// </value>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        /// <value>
        /// The quantity
        /// </value>
        public long Quantity { get; set; }
    }
}