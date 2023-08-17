using Humin_Man.Common.Model.Stock;
using Humin_Man.ViewModels.Stock;
using Humin_Man.ViewModels.Category;
using System.Collections.Generic;
using System.Linq;
using Humin_Man.Common.Model.Product;
using Humin_Man.Common.Model.Shop;
using Humin_Man.ViewModels.Shop;
using Humin_Man.ViewModels.Product;


namespace Humin_Man.Converters
{
    /// <summary>
    /// Stock View Model Converter
    /// </summary>
    public class StockModelConverter
    {
        /// <summary>
        /// Converts a collection of stock models to stock view models.
        /// </summary>
        /// <param name="stocks">The products.</param>
        /// <returns>A collection of stock view models.</returns>
        public ICollection<StockOutputViewModel> Convert(ICollection<StockOutputModel> stocks)
            => stocks?.Select(p => new StockOutputViewModel
            {
                Id = p.Id,
                Quantity = p.Quantity,
                ShopId = p.ShopId,
                ProductId = p.ProductId,
                Shop = new ShopOutputModel
                {
                    Name = p.Shop.Name,
                    Country = new CountryModel
                    {
                        Id = p.Shop.Country.Id,
                        Name = p.Shop.Country.Name
                    },
                    Capacity = p.Shop.Capacity,
                    IsLocked = p.Shop.IsLocked,
                    UpdatedAt = p.Shop.UpdatedAt,
                    Id = p.Shop.Id
                },
                Product = new ProductViewModel
                {
                    Name = p.Product.Name,
                    Id = p.Product.Id,
                    Image = p.Product.Image,
                    Category = new CategoryViewModel
                    {
                        Id = p.Product.Category.Id,
                        Name = p.Product.Category.Name
                    },
                    BuyPrice = p.Product.BuyPrice,
                    SellPrice = p.Product.SellPrice,
                    CategoryId = p.Product.CategoryId,
                    UpdatedAt = p.UpdatedAt,
                },
                UpdatedAt = p.UpdatedAt,
            }).ToList();

        /// <summary>
        /// Converts a stock view model to a stock model.
        /// </summary>
        /// <param name="input">The input stock view model.</param>
        /// <returns>A stock model.</returns>
        public StockOutputModel Convert(StockOutputViewModel input)
            => new StockOutputModel
            {
                Id = input.Id,
                Quantity = input.Quantity,
                ShopId = input.ShopId,
                ProductId = input.ProductId,
                Shop = new ShopOutputModel
                {
                    Name = input.Shop.Name,
                },
                Product = new ProductOutputModel
                {
                    Name = input.Product.Name
                },
                UpdatedAt = input.UpdatedAt,
            };

        /// <summary>
        /// Converts a stock view model to a stock model.
        /// </summary>
        /// <param name="input">The input stock view model.</param>
        /// <returns>A stock model.</returns>
        public AddStockInputModel Convert(AddStockInputViewModel input)
            => new AddStockInputModel
            {
                
                Quantity = input.Quantity,
                ShopId = input.ShopId,
                ProductId = input.ProductId,
            };

        /// <summary>
        /// Converts a stock view model to a stock model.
        /// </summary>
        /// <param name="input">The input stock view model.</param>
        /// <returns>A stock model.</returns>
        public UpdateStockInputModel Convert(UpdateStockInputViewModel input)
            => new UpdateStockInputModel
            {

                Quantity = input.Quantity,
                ShopId = input.ShopId,
                ProductId = input.ProductId,
            };
    }
}