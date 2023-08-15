using Humin_Man.Common.Model.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humin_Man.Common.Service
{
    /// <summary>
    /// Interface that defines the product service.
    /// </summary>
    /// <seealso cref="Humin_Man.Common.Service.IBaseService" />
    public interface IProductService : IBaseService
    {
        /// <summary>
        /// Adds the product asynchronously.
        /// </summary>
        /// <param name="input">Input model for adding product.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        Task AddAsync(ProductModel input);

        /// <summary>
        /// Edits the product asynchronously.
        /// </summary>
        /// <param name="id">The identifier for the product to edit.</param>
        /// <param name="input">Input model for updating product.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        Task UpdateAsync(long id, ProductModel input);

        /// <summary>
        /// Gets the product by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier for the product to retrieve.</param>
        /// <returns>Output model for the requested product.</returns>
        Task<ProductModel> GetAsync(long id);

        /// <summary>
        /// Gets all the products asynchronously.
        /// </summary>
        /// <returns>List of output models for all products.</returns>
        Task<ICollection<ProductModel>> GetAsync();

        /// <summary>
        /// Deletes the product by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier for the product to delete.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        Task DeleteAsync(long id);
    }
}