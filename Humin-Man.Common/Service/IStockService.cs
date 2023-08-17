using Humin_Man.Common.Model.Stock;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humin_Man.Common.Service
{
    /// <summary>
    /// Class that defines the shop service.
    /// </summary>
    /// <seealso cref="Humin_Man.Common.Service.IBaseService" />
    public interface IStockService : IBaseService
    {
        /// <summary>
        /// Adds the asynchronously.
        /// </summary>
        /// <returns></returns>
        Task AddAsync(AddStockInputModel input);

        /// <summary>
        /// Edits the asynchronously.
        /// </summary>
        /// <returns></returns>
        Task UpdateAsync(long id, UpdateStockInputModel input);

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<StockOutputModel> GetAsync(long id);

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<StockOutputModel>> GetAsync();

        /// <summary>
        /// Deletes the asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteAsync(long id);
    }
}
