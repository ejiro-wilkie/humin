using Humin_Man.Core.Entities;
using System.Collections.Generic;

namespace Humin_Man.Entities
{
    /// <summary>
    /// Class that represents the category entity.
    /// </summary>
    /// <seealso cref="Humin_Man.Entities.BaseEnetity" />
    public class Category : BaseEnetity, ICategory
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of products associated with this category.
        /// </summary>
        /// /// <value>
        /// The collection
        /// </value>
        public ICollection<Product> Products { get; set; } = new List<Product>();



    }
}
