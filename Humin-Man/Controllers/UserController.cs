using Humin_Man.Common;
using Humin_Man.Common.Model.User;
using Humin_Man.Common.Service;
using Humin_Man.Constant;
using Humin_Man.Converters;
using Humin_Man.Exceptions;
using Humin_Man.ViewModels;
using Humin_Man.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Humin_Man.Controllers
{
    /// <summary>
    ///     Class that represents the user controller.
    /// </summary>
    /// <seealso cref="BaseController" />
    [Route("[Controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly UserViewModelConverter _userViewModelConverter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The context.</param>
        /// <param name="userService">The user service.</param>
        /// <param name="userViewModelConverter">company view model.</param>
        public UserController(ILogger<UserController> logger, IContext context, IUserService userService,
            UserViewModelConverter userViewModelConverter) : base(logger, context)
        {
            _userService = userService;
            _userViewModelConverter = userViewModelConverter;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var usersModels = await _userService.GetAsync();
                var usersViewModels = _userViewModelConverter.Convert(usersModels);

                return View(usersViewModels);
            }
            catch (HmException eppException)
            {
                Logger.LogError(eppException, "A controlled error happened.");
                return BadRequest(new JsonErrorViewModel(eppException.GetBaseException().Message)); //change this later
            }
            catch (Exception e)
            {
                var message = "An unknown error happened.";
                Logger.LogCritical(e, message);
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new JsonErrorViewModel(message)); //change this later
            }
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Create")]
        public IActionResult Create()
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
        /// Creates the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateUserInputViewModel input)
        {
            try
            {
                await _userService.AddAsync(new CreateUserInputModel
                {
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Password = input.Password,
                    PhoneNumber = input.PhoneNumber,
                    UserName = input.UserName
                });

                TempData["success"] = "New user created successfully";

                return RedirectToAction("Index");
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

            return RedirectToAction("Create");
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("Update/{id}")]
        public async Task<IActionResult> Update(long id)
        {
            try
            {
                var user = await _userService.GetAsync(id);

                var userViewModel = _userViewModelConverter.Convert(user);

                return View(userViewModel);
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

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(UpdateUserInputViewModel input)
        {
            var updateUserInput = _userViewModelConverter.Convert(input);

            await _userService.UpdateAsync(updateUserInput);

            return RedirectToAction("Index");


        }
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                TempData["success"] = "User deleted successfully";
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
            return RedirectToAction("Index");
        }

    }
}