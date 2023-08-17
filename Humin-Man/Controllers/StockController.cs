using Humin_Man.Common;
using Humin_Man.Common.Service;
using Humin_Man.Constant;
using Humin_Man.Converters;
using Humin_Man.Exceptions;
using Humin_Man.ViewModels;
using Humin_Man.ViewModels.Stock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Humin_Man.Controllers
{
    /// <summary>
    /// Class that represents the  controller.
    /// </summary>
    /// <seealso cref="BaseController" />
    [Route("[Controller]")]
    public class StockController : BaseController
    {
        private readonly IStockService _stockService;
        private readonly StockModelConverter _StockModelConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="stockService">The stock service.</param>
        /// <param name="context">The context.</param>
        /// <param name="StockModelConverter">convert from stock model to viewModel.</param>
        public StockController(ILogger<StockController> logger, IStockService stockService, StockModelConverter StockModelConverter, IContext context)
            : base(logger, context)
        {
            _stockService = stockService;
            _StockModelConverter = StockModelConverter;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (HmException eppException)
            {
                Logger.LogError(eppException, "A controlled error happened.");
                TempData["error"] = eppException.Message;
            }
            catch (Exception e)
            {
                var message = "An unknown error happened.";
                Logger.LogCritical(e, message);
                TempData["error"] = WebMessageConstant.UnexpectedErrorOccurred;
            }

            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/stocks")]
        public async Task<IActionResult> GetStocksAsync()
        {
            try
            {
                var stockModels = await _stockService.GetAsync();
                var StockModels = _StockModelConverter.Convert(stockModels);
                return Ok(StockModels);
            }
            catch (HmException eppException)
            {
                Logger.LogError(eppException, "A controlled error happened.");
                return BadRequest(new JsonErrorViewModel(eppException.GetBaseException().Message));
            }
            catch (Exception e)
            {
                var message = "An unknown error happened.";
                Logger.LogCritical(e, message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new JsonErrorViewModel(message));
            }
        }

        /// <summary>
        /// Creates the stock asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost("/api/stock")]
        public async Task<IActionResult> CreateStockAsync([FromBody] AddStockInputViewModel input)
        {
            try
            {
                await _stockService.AddAsync(_StockModelConverter.Convert(input));
                return Ok();
            }
            catch (ArgumentException argEx)
            {
                Logger.LogError(argEx, "An argument error occurred.");
                return BadRequest(new JsonErrorViewModel(argEx.Message));
            }
            catch (HmException eppException)
            {
                Logger.LogError(eppException, "A controlled error happened.");
                return BadRequest(new JsonErrorViewModel(eppException.GetBaseException().Message));
            }
            catch (Exception e)
            {
                var message = "An unknown error happened.";
                Logger.LogCritical(e, message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new JsonErrorViewModel(message));
            }
        }

        /// <summary>
        /// Updates the stock asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost("/api/stock/{id}/update")]
        public async Task<IActionResult> UpdateStockAsync(long id, [FromBody] UpdateStockInputViewModel input)
        {
            try
            {
                await _stockService.UpdateAsync(id, _StockModelConverter.Convert(input));
                return Ok();
            }
            catch (ArgumentException argEx)
            {
                Logger.LogError(argEx, "An argument error occurred.");
                return BadRequest(new JsonErrorViewModel(argEx.Message));
            }
            catch (HmException eppException)
            {
                Logger.LogError(eppException, "A controlled error happened.");
                return BadRequest(new JsonErrorViewModel(eppException.GetBaseException().Message));
            }
            catch (Exception e)
            {
                var message = "An unknown error happened.";
                Logger.LogCritical(e, message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new JsonErrorViewModel(message));
            }
        }

        /// <summary>
        /// Delete the stock asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost("/api/stock/{id}/delete")]
        public async Task<IActionResult> DeleteStockAsync(long id)
        {
            try
            {
                await _stockService.DeleteAsync(id);
                return Ok();
            }
            catch (HmException eppException)
            {
                Logger.LogError(eppException, "A controlled error happened.");
                return BadRequest(new JsonErrorViewModel(eppException.GetBaseException().Message));
            }
            catch (Exception e)
            {
                var message = "An unknown error happened.";
                Logger.LogCritical(e, message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new JsonErrorViewModel(message));
            }
        }
    }
}