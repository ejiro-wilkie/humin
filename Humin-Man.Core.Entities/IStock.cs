using System;
using System.Collections.Generic;
using System.Text;

namespace Humin_Man.Core.Entities
{
    /// <summary>
    /// Class that represents the shop
    /// </summary>
    public interface IStock : IBaseEntity
    {
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
        IShop Shop { get; set; }

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
       IProduct Product { get; set; }

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
    }
}
