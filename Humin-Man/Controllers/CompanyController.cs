using Humin_Man.Common;
using Humin_Man.Common.Service;
using Humin_Man.Constant;
using Humin_Man.Converters;
using Humin_Man.Exceptions;
using Humin_Man.ViewModels;
using Humin_Man.ViewModels.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Humin_Man.Controllers
{
    /// <summary>
    /// Class that represents the company controller.
    /// </summary>
    /// <seealso cref="BaseController" />
    [Route("[Controller]")]
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;
        private readonly CompanyViewModelConverter _companyViewModelConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="companyService">The company service.</param>
        /// <param name="context">The context.</param>
        /// <param name="companyViewModelConverter">convert from company model to viewModel.</param>
        public CompanyController(ILogger<CompanyController> logger, ICompanyService companyService, CompanyViewModelConverter companyViewModelConverter, IContext context) : base(logger, context)
        {
            _companyService = companyService;
            _companyViewModelConverter = companyViewModelConverter;
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
        [HttpGet("/api/companies")]
        public async Task<IActionResult> GetCompaniesAsync()
        {
            try
            {
                var companiesModels = await _companyService.GetAsync();
                var companiesViewModels = _companyViewModelConverter.Convert(companiesModels);
                return Ok(companiesViewModels);
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
        /// Creates the company asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost("/api/company")]
        public async Task<IActionResult> CreateCompanyAsync([FromBody] AddCompanyInputViewModel input)
        {
            try
            {
                await _companyService.AddAsync(_companyViewModelConverter.Convert(input));

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
        /// Updates the company asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost("/api/company/{id}/update")]
        public async Task<IActionResult> UpdateCompanyAsync(long id, [FromBody] UpdateCompanyInputViewModel input)
        {
            try
            {
                await _companyService.UpdateAsync(id, _companyViewModelConverter.Convert(input));

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
        /// Delete the company asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost("/api/company/{id}/delete")]
        public async Task<IActionResult> DeleteCompanyAsync(long id)
        {
            try
            {
                await _companyService.DeleteAsync(id);

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