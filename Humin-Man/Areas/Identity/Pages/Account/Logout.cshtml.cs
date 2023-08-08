using Humin_Man.Common.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Humin_Man.Areas.Identity.Pages.Account
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PageModel" />
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly IAuthService _authService;
        private readonly ILogger<LogoutModel> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogoutModel"/> class.
        /// </summary>
        /// <param name="authService">The authentication service.</param>
        /// <param name="logger">The logger.</param>
        public LogoutModel(IAuthService authService, ILogger<LogoutModel> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        /// <summary>
        /// Called when [get].
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Called when [post].
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _authService.LogoutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage("login");
            }
        }
    }
}
