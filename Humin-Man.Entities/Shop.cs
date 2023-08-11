using Humin_Man.Core.Entities;

namespace Humin_Man.Entities
{
    /// <summary>
    /// Class that represents the companie entity.
    /// </summary>
    /// <seealso cref="Humin_Man.Entities.BaseEnetity" />
    public class Shop : BaseEnetity, IShop
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
        /// Gets or sets the country
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public virtual ICountry Country { get; set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public long CountryId { get; set; }

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
