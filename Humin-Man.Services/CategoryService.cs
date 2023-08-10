using Humin_Man.Common;
using Humin_Man.Common.Model.Category;
using Humin_Man.Common.Repository;
using Humin_Man.Common.Service;
using Humin_Man.Converter;
using Humin_Man.Entities;
using Humin_Man.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humin_Man.Services
{
    /// <summary>
    /// Class that implements <see cref="ICategoryService"/>
    /// </summary>
    /// <seealso cref="Humin_Man.Services.BaseService" />
    /// <seealso cref="Humin_Man.Common.Service.ICategoryService" />
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly CategoryConverter _categoryConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        /// <param name="logger">Provides logging capabilities.</param>
        /// <param name="unitOfWork">Represents a unit of work.</param>
        /// <param name="userContext">The user context.</param>
        /// <param name="categoryConverter">Converts between category entity and model.</param>

        public CategoryService(ILogger<CategoryService> logger, IUnitOfWork unitOfWork, IContext userContext, CategoryConverter categoryConverter)
            : base(unitOfWork, logger, userContext)
        {
            _categoryConverter = categoryConverter;
        }

        /// <summary>
        /// Adds the asynchronously.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task AddAsync(AddCategoryInputModel input)
        {
            if (input == null)
                throw new ArgumentNullHmException(nameof(input));

            if (string.IsNullOrWhiteSpace(input.Name))
                throw new ArgumentNullHmException(nameof(input.Name));

            var category = new Category
            {
                Name = input.Name
            };

            UnitOfWork.Add(category);
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
            var category = await UnitOfWork.FirstOrDefaultAsync<Category>(c => c.Id == id)
                ?? throw new EntityNotFoundHmException(nameof(Category), id);

            UnitOfWork.SoftDelete(category);
            await UnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<CategoryOutputModel> GetAsync(long id)
        {
            var category = await UnitOfWork.FirstOrDefaultAsync<Category>(c => c.Id == id)
                ?? throw new EntityNotFoundHmException(nameof(Category), id);

            return _categoryConverter.EntityToModel(category);
        }

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ICollection<CategoryOutputModel>> GetAsync()
        {
            var categories = await UnitOfWork.Query<Category>().ToListAsync();
            return categories.Select(c => _categoryConverter.EntityToModel(c)).ToList();
        }

        /// <summary>
        /// Updates the asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="input">The input.</param>
        /// <exception cref="EntityNotFoundHmException">Category</exception>
        public async Task UpdateAsync(long id, UpdateCategoryInputModel input)
        {
            var category = await UnitOfWork.FirstOrDefaultAsync<Category>(c => c.Id == id)
                ?? throw new EntityNotFoundHmException(nameof(Category), id);

            category.Name = input.Name;

            UnitOfWork.Update(category);
            await UnitOfWork.SaveAsync();
        }
    }
}
