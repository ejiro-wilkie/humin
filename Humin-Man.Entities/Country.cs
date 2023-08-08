using Humin_Man.Core.Entities;

namespace Humin_Man.Entities
{
    /// <summary>
    /// Class that implements <see cref="ICountry"/>
    /// </summary>
    /// <seealso cref="Humin_Man.Entities.BaseEnetity" />
    /// <seealso cref="Humin_Man.Core.Entities.ICountry" />
    public class Country : BaseEnetity, ICountry
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public string Icon { get; set; }
    }
}
