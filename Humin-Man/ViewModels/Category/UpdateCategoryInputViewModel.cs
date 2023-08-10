namespace Humin_Man.ViewModels.Category
{
    /// <summary>
    /// Class that represents the category update input view model.
    /// </summary>
    public class UpdateCategoryInputViewModel
    {
        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public long CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>
        /// The name of the category.
        /// </value>
        public string Name { get; set; }
    }
}
