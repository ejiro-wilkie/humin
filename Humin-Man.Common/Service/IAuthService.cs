using Humin_Man.Common.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Humin_Man.Common.Service
{
    /// <summary>
    /// Class that defines the auth service.
    /// </summary>
    /// <seealso cref="Humin_Man.Common.Service.IBaseService" />
    public interface IAuthService : IBaseService
    {
        /// <summary>
        /// Logins the user asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        Task LoginAsync(LoginInputModel input);

        /// <summary>
        /// Logouts the user asynchronously.
        /// </summary>
        /// <returns></returns>
        Task LogoutAsync();
    }
}
