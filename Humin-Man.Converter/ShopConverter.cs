using Humin_Man.Common.Model.Shop;
using Humin_Man.Entities;

namespace Humin_Man.Converter
{
    /// <summary>
    /// Class that represents the shop converter.
    /// </summary>
    public class ShopConverter
    {
        public ShopOutputModel EntityToModel(Shop entity)
        {
            if (entity == null)
                return null;

            return new ShopOutputModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Capacity = entity.Capacity,
                IsLocked = entity.IsLocked,
                Country = new CountryModel
                {
                    Name = entity.Country.Name,
                    Id = entity.CountryId
                },
                UpdatedAt = entity.UpdatedAt,
            };
        }
    }
}
