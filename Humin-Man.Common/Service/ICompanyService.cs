using Humin_Man.Common.Model.Company;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humin_Man.Common.Service
{
    /// <summary>
    /// Class that defines the company service.
    /// </summary>
    /// <seealso cref="Humin_Man.Common.Service.IBaseService" />
    public interface ICompanyService : IBaseService
    {
        /// <summary>
        /// Adds the asynchronously.
        /// </summary>
        /// <returns></returns>
        Task AddAsync(AddCompanyInputModel input);

        /// <summary>
        /// Edits the asynchronously.
        /// </summary>
        /// <returns></returns>
        Task UpdateAsync(long id, UpdateCompanyInputModel input);

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<CompanyOutputModel> GetAsync(long id);

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<CompanyOutputModel>> GetAsync();

        /// <summary>
        /// Deletes the asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteAsync(long id);
    }
}
