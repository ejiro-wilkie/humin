namespace Humin_Man.Common.Model.Shop
{
    /// <summary>
    /// Class that represent the input model for updating a shop.
    /// </summary>
    public class UpdateShopInputModel
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

        /// <summary>
        /// Gets or sets the capacity.
        /// </summary>
        /// <value>
        /// The capacity.
        /// </value>
        public int Capacity { get; set; }

        /// <summary>
        /// Gets or sets the IsLocked flag.
        /// </summary>
        /// <value>
        /// The IsLocked value.
        /// </value>
        public bool IsLocked { get; set; }
    }
}
