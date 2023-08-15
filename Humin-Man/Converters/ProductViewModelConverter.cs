using Humin_Man.Common.Model.Product;
using Humin_Man.ViewModels.Product;
using Humin_Man.ViewModels.Category;
using System.Collections.Generic;
using System.Linq;

namespace Humin_Man.Converters
{
    /// <summary>
    /// Product View Model Converter
    /// </summary>
    public class ProductModelConverter
    {
        /// <summary>
        /// Converts a collection of product models to product view models.
        /// </summary>
        /// <param name="products">The products.</param>
        /// <returns>A collection of product view models.</returns>
        public ICollection<ProductViewModel> Convert(ICollection<ProductModel> products)
            => products?.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Category = new CategoryViewModel
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                },
                BuyPrice = p.BuyPrice,
                SellPrice = p.SellPrice,
                CategoryId = p.CategoryId,
                UpdatedAt = p.UpdatedAt,
            }).ToList();

        /// <summary>
        /// Converts a product view model to a product model.
        /// </summary>
        /// <param name="input">The input product view model.</param>
        /// <returns>A product model.</returns>
        public ProductModel Convert(ProductViewModel input)
            => new ProductModel
            {
                Id = input.Id,
                Name = input.Name,
                Image = input.Image,
                BuyPrice = input.BuyPrice,
                SellPrice = input.SellPrice,
                CategoryId = input.CategoryId,
            };
    }
}