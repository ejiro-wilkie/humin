using Humin_Man.Common.Model.Category;
using Humin_Man.ViewModels.Category;
using System.Collections.Generic;
using System.Linq;

namespace Humin_Man.Converters
{
    /// <summary>
    /// Category View Model Converter
    /// </summary>
    public class CategoryViewModelConverter
    {
        /// <summary>
        /// Converts the specified categories.
        /// </summary>
        /// <param name="categories">The categories.</param>
        /// <returns></returns>
        public ICollection<CategoryOutputViewModel> Convert(ICollection<CategoryOutputModel> categories)
            => categories?.Select(c => new CategoryOutputViewModel
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            }).ToList();

        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public AddCategoryInputModel Convert(AddCategoryInputViewModel input)
            => new AddCategoryInputModel
            {
                CategoryId = input.CategoryId,
                Name = input.Name
            };

        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public UpdateCategoryInputModel Convert(UpdateCategoryInputViewModel input)
            => new UpdateCategoryInputModel
            {
                CategoryId = input.CategoryId,
                Name = input.Name
            };
    }
}
