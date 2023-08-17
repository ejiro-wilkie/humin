using Humin_Man.Common.Model.Product;
using Humin_Man.Common.Model.Shop;

namespace Humin_Man.ViewModels.Stock
{
    /// <summary>
    /// Class that represents the shop update input view model.
    /// </summary>
    public class UpdateStockInputViewModel
    {
        /// <summary>
        /// Gets or sets the shop
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public ShopOutputModel Shop { get; set; }

        /// <summary>
        /// Gets or sets the shop identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public long ShopId { get; set; }

        /// <summary>
        /// Gets or sets the product
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public ProductModel Product { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public long ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The capacity.
        /// </value>
        public int Quantity { get; set; }
    }
}
