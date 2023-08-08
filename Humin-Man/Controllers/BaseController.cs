using Humin_Man.Common;
using Humin_Man.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Humin_Man.Controllers
{
    /// <summary>
    /// Class that implements the base controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger<BaseController> Logger;

        /// <summary>
        /// The user context
        /// </summary>
        protected readonly IContext UserContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The context.</param>
        public BaseController(ILogger<BaseController> logger, IContext context)
        {
            Logger = logger;
            UserContext = context;
        }

        /// <summary>
        /// Redirects to default action.
        /// </summary>
        /// <returns></returns>
        protected IActionResult RedirectToDefaultAction() => RedirectToAction("Index", "Home");

        /// <summary>
        /// Throws the model state exception.
        /// </summary>
        /// <exception cref="ModelStateInputHmException"></exception>
        protected void ThrowModelStateException()
        {
            if (!ModelState.IsValid)
                throw new ModelStateInputHmException(GetModelStateErrorsAsList());
        }

        /// <summary>
        /// Gets the model state errors as list.
        /// </summary>
        /// <returns></returns>
        protected ICollection<string> GetModelStateErrorsAsList() => GetModelStateErrors().Select(t => t.ErrorMessage).ToList();

        /// <summary>
        /// Gets the model state errors.
        /// </summary>
        /// <returns></returns>
        protected ICollection<ModelError> GetModelStateErrors() => ModelState.Keys.SelectMany(key => ModelState[key].Errors).ToList();

        /// <summary>
        /// Gets the model state errors as string.
        /// </summary>
        /// <returns></returns>
        /// <remarks>The errors are separated by <see cref="Environment.NewLine"/>.</remarks>
        protected string GetModelStateErrorsAsString() => GetModelStateErrorsAsString(Environment.NewLine);

        /// <summary>
        /// Gets the model state errors as string with <paramref name="separator"/> separator.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        protected string GetModelStateErrorsAsString(string separator) => string.Join(separator, GetModelStateErrors().Select(t => t.ErrorMessage));
    }
}
