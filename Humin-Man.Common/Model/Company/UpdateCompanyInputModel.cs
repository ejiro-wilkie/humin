namespace Humin_Man.Common.Model.Company
{
    /// <summary>
    /// Class that represent the input model for updating a company.
    /// </summary>
    public class UpdateCompanyInputModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public long CountryId { get; set; }
    }
}
