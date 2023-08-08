using Humin_Man.Common;
using Humin_Man.Common.Model.Company;
using Humin_Man.Common.Repository;
using Humin_Man.Common.Service;
using Humin_Man.Converter;
using Humin_Man.Entities;
using Humin_Man.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humin_Man.Services
{
    /// <summary>
    /// Class that implements <see cref="ICompanyService"/>
    /// </summary>
    /// <seealso cref="Humin_Man.Services.BaseService" />
    /// <seealso cref="Humin_Man.Common.Service.ICompanyService" />
    public class CompanyService : BaseService, ICompanyService
    {
        private readonly CompanyConverter _companyConverter;
        private readonly ICountryService _countryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyService" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="userContext">The user context.</param>
        /// <param name="companyConverter">The company converter.</param>
        /// <param name="countryService">The country service.</param>
        public CompanyService(ILogger<CompanyService> logger, IUnitOfWork unitOfWork, IContext userContext, CompanyConverter companyConverter,
            ICountryService countryService) : base(unitOfWork, logger, userContext)
        {
            _companyConverter = companyConverter;
            _countryService = countryService;
        }

        /// <summary>
        /// Adds the asynchronously.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task AddAsync(AddCompanyInputModel input)
        {
            if (input == null)
                throw new ArgumentNullHmException(nameof(input));

            if (string.IsNullOrWhiteSpace(input.Name))
                throw new ArgumentNullHmException(nameof(input.Name));

            if (input.Name.Length < 5 || input.Name.Length > 10)
                throw new InvalidNameHmException(input.Name);

            var country = await UnitOfWork.FirstOrDefaultAsync<Country>(c => c.Id == input.CountryId)
                ?? throw new EntityNotFoundHmException(nameof(Country), input.CountryId);

            var company = new Company
            {
                Name = input.Name,
                Image = input.Image,
                Country = country
            };

            UnitOfWork.Add(company);
            await UnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Deletes the asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task DeleteAsync(long id)
        {
            var company = await UnitOfWork.FirstOrDefaultAsync<Company>(c => c.Id == id)
                ?? throw new EntityNotFoundHmException(nameof(Company), id);

            UnitOfWork.SoftDelete(company);
            await UnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<CompanyOutputModel> GetAsync(long id)
        {
            var company = await UnitOfWork.FirstOrDefaultAsync<Company>(c => c.Id == id)
               ?? throw new EntityNotFoundHmException(nameof(Company), id);

            return _companyConverter.EntityToModel(company);
        }

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ICollection<CompanyOutputModel>> GetAsync()
        {
            var companies = await UnitOfWork.Query<Company>().Include(e => e.Country).ToListAsync(); 

            return companies.Select(c => _companyConverter.EntityToModel(c)).ToList();
        }

        /// <summary>
        /// Updates the asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="input">The input.</param>
        /// <exception cref="EntityNotFoundHmException">Company</exception>
        public async Task UpdateAsync(long id, UpdateCompanyInputModel input)
        {
            var company = await UnitOfWork.FirstOrDefaultAsync<Company>(c => c.Id == id)
               ?? throw new EntityNotFoundHmException(nameof(Company), id);

            if (input.Name.Length < 5 || input.Name.Length > 10)
                throw new InvalidNameHmException(input.Name);

            if (!await _countryService.IsValidCountry(input.CountryId))
                throw new EntityNotFoundHmException(nameof(Country), input.CountryId);

            company.Name = input.Name;
            company.CountryId = id;

            UnitOfWork.Update(company);
            await UnitOfWork.SaveAsync();
        }
    }
}
