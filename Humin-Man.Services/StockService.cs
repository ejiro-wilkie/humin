    using Humin_Man.Common;
    using Humin_Man.Common.Model.Stock;
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
        /// Class that implements <see cref="IStockService"/>
        /// </summary>
        /// <seealso cref="Humin_Man.Services.BaseService" />
        /// <seealso cref="Humin_Man.Common.Service.IStockService" />
        public class StockService : BaseService, IStockService
        {
            private readonly StockConverter _stockConverter;
            private readonly IShopService _shopService;

            /// <summary>
            /// Initializes a new instance of the <see cref="StockService" /> class.
            /// </summary>
            /// <param name="logger">The logger.</param>
            /// <param name="unitOfWork">The unit of work.</param>
            /// <param name="userContext">The user context.</param>
            /// <param name="stockConverter">The stock converter.</param>
            /// <param name="shopService">The shop service.</param>
            public StockService(ILogger<StockService> logger, IUnitOfWork unitOfWork, IContext userContext, StockConverter stockConverter,
                IShopService shopService) : base(unitOfWork, logger, userContext)
            {
                _stockConverter = stockConverter;
                _shopService = shopService;
            }

        /// <summary>
        /// Adds the asynchronously.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task AddAsync(AddStockInputModel input)
        {
            if (input == null)
                throw new ArgumentNullHmException(nameof(input));

            var shop = await UnitOfWork.FirstOrDefaultAsync<Shop>(c => c.Id == input.ShopId)
                ?? throw new EntityNotFoundHmException(nameof(Shop), input.ShopId);

            var product = await UnitOfWork.FirstOrDefaultAsync<Product>(c => c.Id == input.ProductId)
                ?? throw new EntityNotFoundHmException(nameof(Product), input.ProductId);

            DateTime thresholdDateTime = new DateTime(1900, 1, 1);

            var totalCurrentProductsQuantity = await UnitOfWork.Query<Stock>()
                .Where(s => s.Shop.Id == shop.Id && s.DeletedAt < thresholdDateTime)
                .SumAsync(s => s.Quantity);

            var existingStock = await UnitOfWork.FirstOrDefaultAsync<Stock>(s => s.Shop.Id == shop.Id && s.Product.Id == product.Id && s.DeletedAt < thresholdDateTime);

            if (existingStock != null)
            {
                if (totalCurrentProductsQuantity + input.Quantity > shop.Capacity)
                    throw new ArgumentException("The quantity exceeds the shop's capacity.");

                existingStock.Quantity += input.Quantity;
                UnitOfWork.Update(existingStock);
            }
            else
            {
                if (totalCurrentProductsQuantity + input.Quantity > shop.Capacity)
                    throw new ArgumentException("The quantity exceeds the shop's capacity.");

                var stock = new Stock
                {
                    Shop = shop,
                    Product = product,
                    Quantity = input.Quantity
                };

                UnitOfWork.Add(stock);
            }

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
                var stock = await UnitOfWork.FirstOrDefaultAsync<Stock>(c => c.Id == id)
                    ?? throw new EntityNotFoundHmException(nameof(Stock), id);

                stock.DeletedAt = DateTime.Now;

                UnitOfWork.SoftDelete(stock);
                await UnitOfWork.SaveAsync();
            }

            /// <summary>
            /// Gets the asynchronously.
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            /// <exception cref="System.NotImplementedException"></exception>
            public async Task<StockOutputModel> GetAsync(long id)
            {
                var stock = await UnitOfWork.FirstOrDefaultAsync<Stock>(c => c.Id == id)
                   ?? throw new EntityNotFoundHmException(nameof(Stock), id);

                return _stockConverter.EntityToModel(stock);
            }

            /// <summary>
            /// Gets the asynchronously.
            /// </summary>
            /// <returns></returns>
            /// <exception cref="System.NotImplementedException"></exception>
            public async Task<ICollection<StockOutputModel>> GetAsync()
            {
                var stocks = await UnitOfWork.Query<Stock>()
                    .Include(e => e.Shop).Include(e => e.Shop.Country)
                    .Include(e => e.Product).Include(e => e.Product.Category)
                    .ToListAsync(); 

                return stocks.Select(c => _stockConverter.EntityToModel(c)).ToList();
            }

        /// <summary>
        /// Updates the stock asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="input">The input.</param>
        /// <exception cref="EntityNotFoundHmException">Stock</exception>
        public async Task UpdateAsync(long id, UpdateStockInputModel input)
        {
            var stock = await UnitOfWork.FirstOrDefaultAsync<Stock>(c => c.Id == id)
               ?? throw new EntityNotFoundHmException(nameof(Stock), id);

            if (input.Quantity <= 0)
                throw new ArgumentException("Quantity must be a positive value.");

            if (stock.Quantity - input.Quantity < 0)
                throw new ArgumentException("Not enough stock available for this sale.");

            stock.Quantity -= input.Quantity;

            UnitOfWork.Update(stock);
            await UnitOfWork.SaveAsync();
        }

    }
}
