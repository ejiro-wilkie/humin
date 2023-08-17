using System;
using Humin_Man.Common.Model.Category;
using Humin_Man.Common.Model.Product;
using Humin_Man.Common.Model.Shop;
using Humin_Man.Core.Entities;

namespace Humin_Man.Common.Model.Stock
{
    /// <summary>
    /// Class that represents the stock model.
    /// </summary>
    public class StockOutputModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
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
        /// Gets or sets the shop
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public ShopOutputModel Shop { get; set; }

        /// <summary>
        /// Gets or sets the shop identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public long ShopId { get; set; }

        /// <summary>
        /// Gets or sets the product
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public ProductOutputModel Product { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public long ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The capacity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating when this instance was last updated.
        /// </summary>
        /// <value>
        /// The datetime.
        /// </value>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public DateTime UpdatedAt { get; set; }
    }
}