using Humin_Man.Common.Model.Stock;
using Humin_Man.Common.Model.Shop;
using Humin_Man.Common.Model.Product;
using Humin_Man.Common.Model.Category;
using Humin_Man.Entities;

namespace Humin_Man.Converter
{
    /// <summary>
    /// Class that represents the stock converter.
    /// </summary>
    public class StockConverter
    {
        public StockOutputModel EntityToModel(Stock entity)
        {
            if (entity == null)
                return null;

            return new StockOutputModel
            {
                Id = entity.Id,
                Quantity = entity.Quantity,
                ShopId = entity.ShopId,
                ProductId = entity.ProductId,
                Shop = new ShopOutputModel
                {
                    Name = entity.Shop.Name,
                    Country = new CountryModel
                    {
                        Id = entity.Shop.Country.Id,
                        Name = entity.Shop.Country.Name
                    },
                    Capacity = entity.Shop.Capacity,
                    IsLocked = entity.Shop.IsLocked,
                    UpdatedAt = entity.Shop.UpdatedAt,
                    Id = entity.Shop.Id
                },
                Product = new ProductOutputModel
                {
                    Name = entity.Product.Name,
                    Id = entity.Product.Id,
                    Image = entity.Product.Image,
                    Category = new CategoryModel
                    {
                        Id = entity.Product.Category.Id,
                        Name = entity.Product.Category.Name
                    },
                    BuyPrice = entity.Product.BuyPrice,
                    SellPrice = entity.Product.SellPrice,
                    CategoryId = entity.Product.CategoryId,
                    UpdatedAt = entity.UpdatedAt,
                },

                UpdatedAt = entity.UpdatedAt,

            };
        }
    }
}
