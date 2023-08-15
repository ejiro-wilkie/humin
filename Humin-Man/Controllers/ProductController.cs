using Humin_Man.Common;
using Humin_Man.Common.Service;
using Humin_Man.Constant;
using Humin_Man.Converters;
using Humin_Man.Exceptions;
using Humin_Man.ViewModels;
using Humin_Man.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Humin_Man.Controllers
{
    /// <summary>
    /// Class that represents the product controller.
    /// </summary>
    /// <seealso cref="BaseController" />
    [Route("[Controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ProductModelConverter _ProductModelConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="productService">The product service.</param>
        /// <param name="context">The context.</param>
        /// <param name="ProductModelConverter">convert from product model to viewModel.</param>
        public ProductController(ILogger<ProductController> logger, IProductService productService, ProductModelConverter ProductModelConverter, IContext context)
            : base(logger, context)
        {
            _productService = productService;
            _ProductModelConverter = ProductModelConverter;
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
        [HttpGet("/api/products")]
        public async Task<IActionResult> GetProductsAsync()
        {
            try
            {
                var productModels = await _productService.GetAsync();
                var ProductModels = _ProductModelConverter.Convert(productModels);
                return Ok(ProductModels);
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
        /// Creates the product asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost("/api/product")]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductViewModel input)
        {
            try
            {
                await _productService.AddAsync(_ProductModelConverter.Convert(input));
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
        /// Updates the product asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost("/api/product/{id}/update")]
        public async Task<IActionResult> UpdateProductAsync(long id, [FromBody] ProductViewModel input)
        {
            try
            {
                await _productService.UpdateAsync(id, _ProductModelConverter.Convert(input));
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
        /// Delete the product asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost("/api/product/{id}/delete")]
        public async Task<IActionResult> DeleteProductAsync(long id)
        {
            try
            {
                await _productService.DeleteAsync(id);
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
