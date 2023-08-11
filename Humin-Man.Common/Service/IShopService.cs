using Humin_Man.Common.Model.Shop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humin_Man.Common.Service
{
    /// <summary>
    /// Class that defines the shop service.
    /// </summary>
    /// <seealso cref="Humin_Man.Common.Service.IBaseService" />
    public interface IShopService : IBaseService
    {
        /// <summary>
        /// Adds the asynchronously.
        /// </summary>
        /// <returns></returns>
        Task AddAsync(AddShopInputModel input);

        /// <summary>
        /// Edits the asynchronously.
        /// </summary>
        /// <returns></returns>
        Task UpdateAsync(long id, UpdateShopInputModel input);

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<ShopOutputModel> GetAsync(long id);

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<ShopOutputModel>> GetAsync();

        /// <summary>
        /// Deletes the asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteAsync(long id);
    }
}
