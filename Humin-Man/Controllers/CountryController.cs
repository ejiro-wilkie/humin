using Humin_Man.Common;
using Humin_Man.Common.Service;
using Humin_Man.Exceptions;
using Humin_Man.ViewModels;
using Humin_Man.ViewModels.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Humin_Man.Controllers
{
    /// <summary>
    /// Class that represents the shop controller.
    /// </summary>
    /// <seealso cref="BaseController" />
    [Route("Controller")]
    public class CountryController : BaseController
    {
        private readonly ICountryService _countryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The context.</param>
        /// <param name="countryService">The country service.</param>
        public CountryController(ILogger<CountryController> logger, IContext context, ICountryService countryService) : base(logger, context)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// Get Countries
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/countries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var result = await _countryService.GetAsync();

                return Ok(result.Select(c => new CountryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }));
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