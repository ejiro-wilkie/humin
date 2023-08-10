using Humin_Man.Common;
using Humin_Man.Common.Service;
using Humin_Man.Constant;
using Humin_Man.Converters;
using Humin_Man.Exceptions;
using Humin_Man.ViewModels;
using Humin_Man.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Humin_Man.Controllers
{
    /// <summary>
    /// Class that represents the category controller.
    /// </summary>
    /// <seealso cref="BaseController" />
    [Route("[Controller]")]
    public class CategoryController : BaseController
    {
        // TODO: Replace with services you need
        private readonly ICategoryService _categoryService;
        private readonly CategoryViewModelConverter _categoryViewModelConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="categoryService">The category service.</param>
        /// <param name="context">The context.</param>
        /// <param name="categoryViewModelConverter">convert from category model to viewModel.</param>
        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService, CategoryViewModelConverter categoryViewModelConverter, IContext context)
            : base(logger, context)
        {
            _categoryService = categoryService;
            _categoryViewModelConverter = categoryViewModelConverter;
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
        [HttpGet("/api/categories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            try
            {
                var categoryModels = await _categoryService.GetAsync();
                var categoryViewModels = _categoryViewModelConverter.Convert(categoryModels);
                return Ok(categoryViewModels);
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
        /// Creates the category asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost("/api/category")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] AddCategoryInputViewModel input)
        {
            try
            {
                await _categoryService.AddAsync(_categoryViewModelConverter.Convert(input));
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
        /// Updates the category asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost("/api/category/{id}/update")]
        public async Task<IActionResult> UpdateCategoryAsync(long id, [FromBody] UpdateCategoryInputViewModel input)
        {
            try
            {
                await _categoryService.UpdateAsync(id, _categoryViewModelConverter.Convert(input));
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
        /// Delete the category asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost("/api/category/{id}/delete")]
        public async Task<IActionResult> DeleteCategoryAsync(long id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);
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
