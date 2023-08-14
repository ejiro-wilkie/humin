using Humin_Man.Common.Model.Category;
using Humin_Man.Entities;

namespace Humin_Man.Converter
{
    /// <summary>
    /// Class that represents the category converter.
    /// </summary>
    public class CategoryConverter
    {
        public CategoryModel EntityToModel(Category entity)
        {
            if (entity == null)
                return null;

            return new CategoryModel
            {
                Id = entity.Id,
                Name = entity.Name,
                UpdatedAt = entity.UpdatedAt,
            };
        }
    }
}
