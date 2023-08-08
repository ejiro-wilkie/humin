using Humin_Man.Core.Entities;

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
    }
}
