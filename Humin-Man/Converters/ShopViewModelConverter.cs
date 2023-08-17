using Humin_Man.Common.Model.Shop;
using Humin_Man.ViewModels.Shop;
using System.Collections.Generic;
using System.Linq;

namespace Humin_Man.Converters
{
    /// <summary>
    /// Shop View Model Converter
    /// </summary>
    public class ShopViewModelConverter
    {

        /// <summary>
        /// Converts the specified shops.
        /// </summary>
        /// <param name="shops">The shops.</param>
        /// <returns></returns>
        public ICollection<ShopOutputViewModel> Convert(ICollection<ShopOutputModel> shops)
            => shops?.Select(c => new ShopOutputViewModel
            {
                Name = c.Name,
                Country = new CountryViewModel
                {
                    Id = c.Country.Id,
                    Name = c.Country.Name
                },
                Capacity = c.Capacity,
                IsLocked = c.IsLocked,
                UpdatedAt = c.UpdatedAt,
                Id = c.Id
            }).ToList();

        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public AddShopInputModel Convert(AddShopInputViewModel input)
            => new AddShopInputModel
            {
                CountryId = input.CountryId,
                Name = input.Name,
                Capacity = input.Capacity
            };

        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public UpdateShopInputModel Convert(UpdateShopInputViewModel input)
            => new UpdateShopInputModel
            {
                Name = input.Name,
                CountryId = input.CountryId,
                Capacity = input.Capacity
            };
    }
}