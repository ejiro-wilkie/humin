using System;

namespace Humin_Man.ViewModels.Category
{
    /// <summary>
    /// Class that represents the add category input view model.
    /// </summary>
    public class CategoryViewModel
    {
        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating when this instance was last updated.
        /// </summary>
        /// <value>
        /// The datetime.
        /// </value>
        public DateTime UpdatedAt { get; set; }
    }
}
