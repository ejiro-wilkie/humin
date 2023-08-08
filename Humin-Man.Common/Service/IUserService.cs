using Humin_Man.Common.Model.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humin_Man.Common.Service
{
    /// <summary>
    /// Class that represnets the user service
    /// </summary>
    /// <seealso cref="Humin_Man.Common.Service.IBaseService" />
    public interface IUserService : IBaseService
    {
        /// <summary>
        /// Adds the asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        Task AddAsync(CreateUserInputModel input);

        /// <summary>
        /// Gets the user asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserModel> GetAsync(long id);

        /// <summary>
        /// Gets the user asynchronously
        /// </summary>
        /// <returns></returns>
        Task<List<UserModel>> GetAsync();

        /// <summary>
        /// Updates the user asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        Task UpdateAsync(UpdateUserInputModel input);
    }
}
