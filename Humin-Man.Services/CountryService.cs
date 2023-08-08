using Humin_Man.Common;
using Humin_Man.Common.Model;
using Humin_Man.Common.Repository;
using Humin_Man.Common.Service;
using Humin_Man.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humin_Man.Services
{
    /// <summary>
    /// Class that implements the <see cref="ICountryService"/>
    /// </summary>
    /// <seealso cref="Humin_Man.Services.BaseService" />
    /// <seealso cref="Humin_Man.Common.Service.ICountryService" />
    public class CountryService : BaseService, ICountryService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The context.</param>
        public CountryService(IUnitOfWork unitOfWork, ILogger<CountryService> logger, IContext context) : base(unitOfWork, logger, context)
        { }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<CountryModel>> GetAsync()
        {
            var countries = await UnitOfWork.GetAsync<Country>();

            return countries.Select(c => new CountryModel
            {
                Name = c.Name,
                Id = c.Id
            }).ToList();
        }

        /// <summary>
        /// Determines whether [is valid country] [the specified identifier].
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <c>true</c> if [is valid country] [the specified identifier]; otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> IsValidCountry(long id) => await UnitOfWork.AnyAsync<Country>(c => c.Id == id);
    }
}
