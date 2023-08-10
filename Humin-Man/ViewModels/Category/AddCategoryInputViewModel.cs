namespace Humin_Man.ViewModels.Category
{
    /// <summary>
    /// Class that represents the add category input view model.
    /// </summary>
    public class AddCategoryInputViewModel
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
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
