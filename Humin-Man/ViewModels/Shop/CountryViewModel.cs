using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humin_Man.ViewModels.Shop
{
    /// <summary>
    /// Class that represents the country view model.
    /// </summary>
    public class CountryViewModel
    {
        /// <summary>
        /// Gets the identifier.
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
    }
}
