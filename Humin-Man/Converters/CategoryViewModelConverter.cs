using Humin_Man.Common.Model.Category;
using Humin_Man.ViewModels.Category;
using System.Collections.Generic;
using System.Linq;

namespace Humin_Man.Converters
{
    /// <summary>
    /// Category View Model Converter
    /// </summary>
    public class CategoryModelConverter
    {
        /// <summary>
        /// Converts the specified categories.
        /// </summary>
        /// <param name="categories">The categories.</param>
        /// <returns></returns>
        public ICollection<ViewModels.Category.CategoryViewModel> Convert(ICollection<Common.Model.Category.CategoryModel> categories)
            => categories?.Select(c => new ViewModels.Category.CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                UpdatedAt = c.UpdatedAt,
            }).ToList();


        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public Common.Model.Category.CategoryModel Convert(ViewModels.Category.CategoryViewModel input)
            => new Common.Model.Category.CategoryModel
            {
                Id = input.Id,
                Name = input.Name
            };

    }
}
