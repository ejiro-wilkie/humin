using System;
using System.Collections.Generic;
using System.Text;

namespace Humin_Man.Core.Entities
{
    /// <summary>
    /// Interface that defines the category service.
    /// </summary>
    public interface ICategory : IBaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }


        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        long CategoryId { get; set; }
    }
}
