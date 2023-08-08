using Humin_Man.Auth.Managers;
using Humin_Man.Common;
using Humin_Man.Common.Model.Authentication;
using Humin_Man.Common.Repository;
using Humin_Man.Common.Service;
using Humin_Man.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Humin_Man.Services
{
    /// <summary>
    /// Class that implements <see cref="IAuthService"/>.
    /// </summary>
    /// <seealso cref="Humin_Man.Services.BaseService" />
    /// <seealso cref="Humin_Man.Common.Service.IAuthService" />
    public class AuthService : BaseService, IAuthService
    {
        private readonly HuminSingInManager _huminSingInManager;
        private readonly HuminUserManager _huminUserManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="huminSingInManager">The humin sing in manager.</param>
        /// <param name="huminUserManager">The humin user manager.</param>
        /// <param name="userContext">The user context.</param>
        public AuthService(IUnitOfWork unitOfWork, ILogger<AuthService> logger, HuminSingInManager huminSingInManager, HuminUserManager huminUserManager, IContext userContext) : base(unitOfWork, logger, userContext)
        {
            _huminSingInManager = huminSingInManager;
            _huminUserManager = huminUserManager;
        }

        /// <summary>
        /// Logins the user asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task LoginAsync(LoginInputModel input)
        {
            Logger.LogInformation($"Getting user {input.Email}");

            var user = await _huminUserManager.FindByEmailAsync(input.Email);
            if (user is null)
                throw new EntityNotFoundHmException(nameof(user), input.Email);

            Logger.LogInformation($"Attempting to login user {input.Email}");

            var signInResult = await _huminSingInManager.PasswordSignInAsync(user, input.Password, false, false);

            if (signInResult.IsLockedOut)
                throw new UserLockedOutHmException(input.Email);

            if (!signInResult.Succeeded)
                throw new InvalidCredentialsHmException(input.Email, input.Password);

            Logger.LogInformation($"User {input.Email} logged in successfully!");
        }

        /// <summary>
        /// Logouts the user asynchronously.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task LogoutAsync()
        {
            await _huminSingInManager.SignOutAsync();
            Logger.LogInformation("User logged out.");
        }
    }
}
