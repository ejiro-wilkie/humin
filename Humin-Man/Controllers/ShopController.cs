using Humin_Man.Common;
using Humin_Man.Common.Service;
using Humin_Man.Constant;
using Humin_Man.Converters;
using Humin_Man.Exceptions;
using Humin_Man.ViewModels;
using Humin_Man.ViewModels.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Humin_Man.Controllers
{
    /// <summary>
    /// Class that represents the shop controller.
    /// </summary>
    /// <seealso cref="BaseController" />
    [Route("[Controller]")]
    public class ShopController : BaseController
    {
        private readonly IShopService _shopService;
        private readonly ShopViewModelConverter _shopViewModelConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="shopService">The shop service.</param>
        /// <param name="context">The context.</param>
        /// <param name="shopViewModelConverter">convert from shop model to viewModel.</param>
        public ShopController(ILogger<ShopController> logger, IShopService shopService, ShopViewModelConverter shopViewModelConverter, IContext context) : base(logger, context)
        {
            _shopService = shopService;
            _shopViewModelConverter = shopViewModelConverter;
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
        [HttpGet("/api/shops")]
        public async Task<IActionResult> GetShopsAsync()
        {
            try
            {
                var shopsModels = await _shopService.GetAsync();
                var shopsViewModels = _shopViewModelConverter.Convert(shopsModels);
                return Ok(shopsViewModels);
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
        /// Creates the shop asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost("/api/shop")]
        public async Task<IActionResult> CreateShopAsync([FromBody] AddShopInputViewModel input)
        {
            try
            {
                await _shopService.AddAsync(_shopViewModelConverter.Convert(input));

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

        /// <summary>
        /// Updates the shop asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost("/api/shop/{id}/update")]
        public async Task<IActionResult> UpdateShopAsync(long id, [FromBody] UpdateShopInputViewModel input)
        {
            try
            {
                await _shopService.UpdateAsync(id, _shopViewModelConverter.Convert(input));

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


        /// <summary>
        /// Delete the shop asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost("/api/shop/{id}/delete")]
        public async Task<IActionResult> DeleteShopAsync(long id)
        {
            try
            {
                await _shopService.DeleteAsync(id);

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