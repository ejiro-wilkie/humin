using System;
using Humin_Man.Auth.Managers;
using Humin_Man.Common.Model.Authentication;
using Humin_Man.Common.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Humin_Man.Exceptions;
using Humin_Man.ViewModels;

namespace Humin_Man.Areas.Identity.Pages.Account
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IAuthService _authService;
        private readonly ILogger<LoginModel> _logger;
        private readonly HuminSingInManager _signInManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginModel" /> class.
        /// </summary>
        /// <param name="authService">The authentication service.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="signInManager">The sign in manager.</param>
        public LoginModel(IAuthService authService, ILogger<LoginModel> logger, HuminSingInManager signInManager)
        {
            _authService = authService;
            _logger = logger;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <value>
        /// The input.
        /// </value>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// Gets or sets the external logins.
        /// </summary>
        /// <value>
        /// The external logins.
        /// </value>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>
        /// The return URL.
        /// </value>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public class InputModel
        {
            /// <summary>
            /// Gets or sets the email.
            /// </summary>
            /// <value>
            /// The email.
            /// </value>
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            /// <summary>
            /// Gets or sets the password.
            /// </summary>
            /// <value>
            /// The password.
            /// </value>
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether [remember me].
            /// </summary>
            /// <value>
            ///   <c>true</c> if [remember me]; otherwise, <c>false</c>.
            /// </value>
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        /// <summary>
        /// Called when [get asynchronous].
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        /// <summary>
        /// Called when [post asynchronous].
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                try
                {

                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    await _authService.LoginAsync(new LoginInputModel
                    {
                        Email = Input.Email,
                        Password = Input.Password
                    });

                    _logger.LogInformation("User logged in.");

                    return LocalRedirect(returnUrl);
                }
                catch (HmException eppException)
                {
                    _logger.LogError(eppException, "A controlled error happened.");
                }
                catch (Exception e)
                {
                    var message = "An unknown error happened.";
                    _logger.LogCritical(e, message);
                }
            }

            TempData["error"] = "Wrong password, please try again";

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}