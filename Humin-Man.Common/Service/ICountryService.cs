using Humin_Man.Common.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humin_Man.Common.Service
{
    /// <summary>
    /// Class that defines the country service.
    /// </summary>
    /// <seealso cref="Humin_Man.Common.Service.IBaseService" />
    public interface ICountryService : IBaseService
    {
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<CountryModel>> GetAsync();

        /// <summary>
        /// Determines whether [is valid country] [the specified identifier].
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <c>true</c> if [is valid country] [the specified identifier]; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> IsValidCountry(long id);
    }
}
