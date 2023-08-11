using Humin_Man.Common.Model.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humin_Man.Common.Service
{
    /// <summary>
    /// Class that defines the category service.
    /// </summary>
    /// <seealso cref="Humin_Man.Common.Service.IBaseService" />
    public interface ICategoryService : IBaseService
    {
        /// <summary>
        /// Adds the category asynchronously.
        /// </summary>
        /// <param name="input">Input model for adding category.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        Task AddAsync(CategoryModel input);

        /// <summary>
        /// Edits the category asynchronously.
        /// </summary>
        /// <param name="id">The identifier for the category to edit.</param>
        /// <param name="input">Input model for updating category.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        Task UpdateAsync(long id, CategoryModel input);

        /// <summary>
        /// Gets the category by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier for the category to retrieve.</param>
        /// <returns>Output model for the requested category.</returns>
        Task<CategoryModel> GetAsync(long id);

        /// <summary>
        /// Gets all the categories asynchronously.
        /// </summary>
        /// <returns>List of output models for all categories.</returns>
        Task<ICollection<CategoryModel>> GetAsync();

        /// <summary>
        /// Deletes the category by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier for the category to delete.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        Task DeleteAsync(long id);
    }
}
