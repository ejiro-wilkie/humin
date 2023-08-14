using Humin_Man.Core.Entities;
using System;

namespace Humin_Man.Entities
{
    /// <summary>
    /// Class that implements <see cref="IBaseEntity"/>
    /// </summary>
    /// <seealso cref="Humin_Man.Core.Entities.IBaseEntity" />
    public class BaseEnetity : IBaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating when this instance was created.
        /// </summary>
        /// <value>
        /// The datetime.
        /// </value>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets a value indicating when this instance was last updated.
        /// </summary>
        /// <value>
        /// The datetime.
        /// </value>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating when this instance was deleted.
        /// </summary>
        /// <value>
        /// The datetime.
        /// </value>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public DateTime DeletedAt { get; set; }
    }
}
