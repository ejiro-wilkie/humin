using Humin_Man.Core.Entities;

namespace Humin_Man.Entities
{
    /// <summary>
    /// Class that represents the category entity.
    /// </summary>
    /// <seealso cref="Humin_Man.Entities.BaseEnetity" />
    public class Category : BaseEnetity
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public long CategoryId { get; set; }

    }
}
