using Humin_Man.Auth.Managers;
using Humin_Man.Common;
using Humin_Man.Common.Model.User;
using Humin_Man.Common.Repository;
using Humin_Man.Common.Service;
using Humin_Man.Converter;
using Humin_Man.Entities;
using Humin_Man.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humin_Man.Services
{
    /// <summary>
    /// Class that implemtns <see cref="IUserService"/>.
    /// </summary>
    /// <seealso cref="BaseService" />
    /// <seealso cref="IUserService" />
    public class UserService : BaseService, IUserService
    {
        private readonly HuminUserManager _userManager;
        private readonly UserConverter _userConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="userConverter">The user converter.</param>
        public UserService(ILogger<UserService> logger, IUnitOfWork unitOfWork, IContext context, HuminUserManager userManager, UserConverter userConverter) : base(unitOfWork, logger, context)
        {
            _userManager = userManager;
            _userConverter = userConverter;
        }

        /// <summary>
        /// Adds the asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task AddAsync(CreateUserInputModel input)
        {
            if (input == null)
                throw new ArgumentNullHmException(nameof(input));
            if (string.IsNullOrWhiteSpace(input.Email))
                throw new ArgumentNullHmException(nameof(input.Email));
            if (string.IsNullOrWhiteSpace(input.FirstName))
                throw new ArgumentNullHmException(nameof(input.FirstName));
            if (string.IsNullOrWhiteSpace(input.LastName))
                throw new ArgumentNullHmException(nameof(input.LastName));
            if (string.IsNullOrWhiteSpace(input.UserName))
                throw new ArgumentNullHmException(nameof(input.UserName));
            if (string.IsNullOrWhiteSpace(input.PhoneNumber))
                throw new ArgumentNullHmException(nameof(input.PhoneNumber));
            if (string.IsNullOrWhiteSpace(input.Password))
                throw new ArgumentNullHmException(nameof(input.Password));

            var user = new User
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.UserName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, input.Password);
            if (!result.Succeeded)
            {
                throw new HmException($"User creation failed: {result.Errors.FirstOrDefault()?.Description}");
            }
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserModel>> GetAsync()
        {
            var users = await UnitOfWork.GetAsync<User>();

            return users.Select(u => _userConverter.EntityToModel(u)).ToList();
        }

        /// <summary>
        /// Gets the user asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserModel> GetAsync(long id)
        {
            var user = await UnitOfWork.FirstOrDefaultAsync<User>(u => u.Id == id);

            return _userConverter.EntityToModel(user);
        }


        /// <summary>
        /// Updates the user asynchronously.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UpdateAsync(UpdateUserInputModel input)
        {
            if (input == null)
                throw new ArgumentNullHmException(nameof(input));
            if (string.IsNullOrWhiteSpace(input.Email))
                throw new ArgumentNullHmException(nameof(input.Email));
            if (string.IsNullOrWhiteSpace(input.FirstName))
                throw new ArgumentNullHmException(nameof(input.FirstName));
            if (string.IsNullOrWhiteSpace(input.LastName))
                throw new ArgumentNullHmException(nameof(input.LastName));
            if (string.IsNullOrWhiteSpace(input.UserName))
                throw new ArgumentNullHmException(nameof(input.UserName));
            if (string.IsNullOrWhiteSpace(input.PhoneNumber))
                throw new ArgumentNullHmException(nameof(input.PhoneNumber));
            if (string.IsNullOrWhiteSpace(input.Password))
                throw new ArgumentNullHmException(nameof(input.Password));



            var user = await _userManager.FindByIdAsync(input.Id.ToString());

            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.UserName = input.UserName;
            user.Email = input.Email;
            user.PhoneNumber = input.PhoneNumber;

            await _userManager.UpdateAsync(user);
        }
    }


}
