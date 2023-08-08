using Humin_Man.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Humin_Man.Auth.Managers
{
    /// <summary>
    /// Class that manages the signing in procedure.
    /// </summary>
    /// <seealso cref="SignInManager{User}" />
    public class HuminSingInManager : SignInManager<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HuminSingInManager" /> class.
        /// </summary>
        /// <param name="userManager">An instance of <see cref="P:Microsoft.AspNetCore.Identity.SignInManager`1.UserManager" /> used to retrieve users from and persist users.</param>
        /// <param name="contextAccessor">The accessor used to access the <see cref="T:Microsoft.AspNetCore.Http.HttpContext" />.</param>
        /// <param name="claimsFactory">The factory to use to create claims principals for a user.</param>
        /// <param name="optionsAccessor">The accessor used to access the <see cref="T:Microsoft.AspNetCore.Identity.IdentityOptions" />.</param>
        /// <param name="logger">The logger used to log messages, warnings and errors.</param>
        /// <param name="schemes">The scheme provider that is used enumerate the authentication schemes.</param>
        /// <param name="userConfirmation">The user confirmation.</param>
        public HuminSingInManager(HuminUserManager userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<User> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<HuminSingInManager> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<User> userConfirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, userConfirmation)
        {
        }
    }
}
