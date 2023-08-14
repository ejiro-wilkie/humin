using System;

namespace Humin_Man.Common.Model.Shop
{
    /// <summary>
    /// Class that represent the shop output model.
    /// </summary>
    public class ShopOutputModel
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
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public CountryModel Country { get; set; }

        /// <summary>
        /// Gets or sets the capacity.
        /// </summary>
        /// <value>
        /// The capacity.
        /// </value>
        public int Capacity { get; set; }

        /// <summary>
        /// Gets or sets the IsLocked flag.
        /// </summary>
        /// <value>
        /// The IsLocked value.
        /// </value>
        public bool IsLocked { get; set; }

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
