using Humin_Man.Common.Model.Company;
using Humin_Man.Entities;

namespace Humin_Man.Converter
{
    /// <summary>
    /// Class that represents the company converter.
    /// </summary>
    public class CompanyConverter
    {
        public CompanyOutputModel EntityToModel(Company entity)
        {
            if (entity == null)
                return null;

            return new CompanyOutputModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Country = new CountryModel
                {
                    Name = entity.Country.Name,
                    Id = entity.CountryId
                }
            };
        }
    }
}
