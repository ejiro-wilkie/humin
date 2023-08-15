using Humin_Man.Common.Model.Product;
using Humin_Man.Common.Model.Category;
using Humin_Man.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humin_Man.Converter
{
    /// <summary>
    /// Class that represents the product converter.
    /// </summary>
    public class ProductConverter
    {
        public ProductModel EntityToModel(Product entity)
        {
            if (entity == null)
                return null;


            return new ProductModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Image = entity.Image,
                BuyPrice = entity.BuyPrice,
                SellPrice = entity.SellPrice,
                Category = new CategoryModel
                {
                    Name = entity.Category.Name,
                    Id = entity.CategoryId
                },
                UpdatedAt = entity.UpdatedAt,
            };
        }

    }
}
