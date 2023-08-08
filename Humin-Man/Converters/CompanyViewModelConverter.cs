using Humin_Man.Common.Model.Company;
using Humin_Man.ViewModels.Company;
using System.Collections.Generic;
using System.Linq;

namespace Humin_Man.Converters
{
    /// <summary>
    /// Company View Model Converter
    /// </summary>
    public class CompanyViewModelConverter
    {

        /// <summary>
        /// Converts the specified companies.
        /// </summary>
        /// <param name="companies">The companies.</param>
        /// <returns></returns>
        public ICollection<CompanyOutputViewModel> Convert(ICollection<CompanyOutputModel> companies)
            => companies?.Select(c => new CompanyOutputViewModel
            {
                Name = c.Name,
                Country = new CountryViewModel
                {
                    Id = c.Country.Id,
                    Name = c.Country.Name
                },
                Id = c.Id
            }).ToList();

        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public AddCompanyInputModel Convert(AddCompanyInputViewModel input)
            => new AddCompanyInputModel
            {
                CountryId = input.CountryId,
                Name = input.Name
            };

        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public UpdateCompanyInputModel Convert(UpdateCompanyInputViewModel input)
            => new UpdateCompanyInputModel
            {
                Name = input.Name,
                CountryId = input.CountryId
            };
    }
}