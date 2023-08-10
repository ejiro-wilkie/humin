namespace Humin_Man.Common.Model.Category
{
    /// <summary>
    /// Class that represents the category output model.
    /// </summary>
    public class CategoryOutputModel
    {
        /// <summary>
        /// Gets or sets the identifier of the category.
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
