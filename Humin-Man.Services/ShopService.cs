using Humin_Man.Common;
using Humin_Man.Common.Model.Shop;
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
    /// Class that implements <see cref="IShopService"/>
    /// </summary>
    /// <seealso cref="Humin_Man.Services.BaseService" />
    /// <seealso cref="Humin_Man.Common.Service.IShopService" />
    public class ShopService : BaseService, IShopService
    {
        private readonly ShopConverter _shopConverter;
        private readonly ICountryService _countryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopService" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="userContext">The user context.</param>
        /// <param name="shopConverter">The shop converter.</param>
        /// <param name="countryService">The country service.</param>
        public ShopService(ILogger<ShopService> logger, IUnitOfWork unitOfWork, IContext userContext, ShopConverter shopConverter,
            ICountryService countryService) : base(unitOfWork, logger, userContext)
        {
            _shopConverter = shopConverter;
            _countryService = countryService;
        }

        /// <summary>
        /// Adds the asynchronously.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task AddAsync(AddShopInputModel input)
        {
            if (input == null)
                throw new ArgumentNullHmException(nameof(input));

            if (string.IsNullOrWhiteSpace(input.Name))
                throw new ArgumentNullHmException(nameof(input.Name));

            if (input.Name.Length < 5 || input.Name.Length > 10)
                throw new InvalidNameHmException(input.Name);

            var country = await UnitOfWork.FirstOrDefaultAsync<Country>(c => c.Id == input.CountryId)
                ?? throw new EntityNotFoundHmException(nameof(Country), input.CountryId);

            var shop = new Shop
            {
                Name = input.Name,
                Image = input.Image,
                Country = country
            };

            UnitOfWork.Add(shop);
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
            var shop = await UnitOfWork.FirstOrDefaultAsync<Shop>(c => c.Id == id)
                ?? throw new EntityNotFoundHmException(nameof(Shop), id);

            UnitOfWork.SoftDelete(shop);
            await UnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ShopOutputModel> GetAsync(long id)
        {
            var shop = await UnitOfWork.FirstOrDefaultAsync<Shop>(c => c.Id == id)
               ?? throw new EntityNotFoundHmException(nameof(Shop), id);

            return _shopConverter.EntityToModel(shop);
        }

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ICollection<ShopOutputModel>> GetAsync()
        {
            var shops = await UnitOfWork.Query<Shop>().Include(e => e.Country).ToListAsync(); 

            return shops.Select(c => _shopConverter.EntityToModel(c)).ToList();
        }

        /// <summary>
        /// Updates the asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="input">The input.</param>
        /// <exception cref="EntityNotFoundHmException">Shop</exception>
        public async Task UpdateAsync(long id, UpdateShopInputModel input)
        {
            var shop = await UnitOfWork.FirstOrDefaultAsync<Shop>(c => c.Id == id)
               ?? throw new EntityNotFoundHmException(nameof(Shop), id);

            if (input.Name.Length < 5 || input.Name.Length > 10)
                throw new InvalidNameHmException(input.Name);

            if (!await _countryService.IsValidCountry(input.CountryId))
                throw new EntityNotFoundHmException(nameof(Country), input.CountryId);

            shop.Name = input.Name;
            shop.CountryId = id;

            UnitOfWork.Update(shop);
            await UnitOfWork.SaveAsync();
        }
    }
}
