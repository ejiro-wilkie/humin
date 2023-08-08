using System;
using System.Collections.Generic;
using System.Text;

namespace Humin_Man.Core.Entities
{
    public interface ICountry : IBaseEntity
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
