using Humin_Man.Common;
using Humin_Man.Common.Model.Product;
using Humin_Man.Common.Repository;
using Humin_Man.Common.Service;
using Humin_Man.Converter;
using Humin_Man.Entities;
using Humin_Man.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humin_Man.Services
{
    /// <summary>
    /// Class that implements <see cref="IProductService"/>
    /// </summary>
    /// <seealso cref="Humin_Man.Services.BaseService" />
    /// <seealso cref="Humin_Man.Common.Service.IProductService" /> 
    public class ProductService : BaseService, IProductService  //
    {
        private readonly ProductConverter _productConverter;  //

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="logger">Provides logging capabilities.</param>
        /// <param name="unitOfWork">Represents a unit of work.</param>
        /// <param name="userContext">The user context.</param>
        /// <param name="productConverter">Converts between product entity and model.</param>
        public ProductService(ILogger<ProductService> logger, IUnitOfWork unitOfWork, IContext userContext, ProductConverter productConverter)
            : base(unitOfWork, logger, userContext)
        {
            _productConverter = productConverter;
        }
        /// <summary>
        /// Adds the asynchronously.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task AddAsync(ProductModel input)
        {
            if (input == null)
                throw new ArgumentNullHmException(nameof(input));

            if (string.IsNullOrWhiteSpace(input.Name))
                throw new ArgumentNullHmException(nameof(input.Name));

            var category = await UnitOfWork.FirstOrDefaultAsync<Category>(c => c.Id == input.CategoryId)
                           ?? throw new EntityNotFoundHmException(nameof(Category), input.CategoryId);

            var product = new Product
            {
                Name = input.Name,
                Category = category,
                SellPrice = input.SellPrice,
                BuyPrice = input.BuyPrice,
                Image = input.Image,
            };

            UnitOfWork.Add(product);
            await UnitOfWork.SaveAsync();
        }


        /// <summary>
        /// Deletes the asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task DeleteAsync(long id)
        {
            var product = await UnitOfWork.FirstOrDefaultAsync<Product>(p => p.Id == id)
                ?? throw new EntityNotFoundHmException(nameof(Product), id);

            product.DeletedAt = DateTime.Now;

            UnitOfWork.SoftDelete(product);
            await UnitOfWork.SaveAsync();
        }


        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ProductModel> GetAsync(long id)
        {
            var product = await UnitOfWork.FirstOrDefaultAsync<Product>(p => p.Id == id)
                ?? throw new EntityNotFoundHmException(nameof(Product), id);

            return _productConverter.EntityToModel(product);
        }

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ICollection<ProductModel>> GetAsync()
        {
            var products = await UnitOfWork.Query<Product>().Include(p => p.Category).ToListAsync();
            return products.Select(p => _productConverter.EntityToModel(p)).ToList();
        }

        /// <summary>
        /// Updates the asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="input">The input.</param>
        /// <exception cref="EntityNotFoundHmException">Category</exception>
        public async Task UpdateAsync(long id, ProductModel input)
        {
            var product = await UnitOfWork.FirstOrDefaultAsync<Product>(p => p.Id == id)
                ?? throw new EntityNotFoundHmException(nameof(Product), id);

            product.Name = input.Name;
            product.CategoryId = input.CategoryId;
            product.SellPrice = input.SellPrice;
            product.BuyPrice = input.BuyPrice;
            product.UpdatedAt = DateTime.Now;

            UnitOfWork.Update(product);
            await UnitOfWork.SaveAsync();
        }
    }
}