using System;
using System.Collections.Generic;
using System.Text;

namespace Humin_Man.Core.Entities
{
    /// <summary>
    /// Class that represents the shop
    /// </summary>
    public interface IShop : IBaseEntity
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
        ICountry Country { get; set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        long CountryId { get; set; }

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
    }
}
