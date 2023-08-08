namespace Humin_Man.ViewModels.Company
{
    /// <summary>
    /// Class that represents the add company input view model.
    /// </summary>
    public class AddCompanyInputViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public long CountryId { get; set; }
    }
}
