using Humin_Man.Common.Model.User;
using Humin_Man.ViewModels.User;
using System.Collections.Generic;
using System.Linq;

namespace Humin_Man.Converters
{
    /// <summary>
    /// User View Model Converter
    /// </summary>
    public class UserViewModelConverter
    {
        /// <summary>
        /// Converts the specified users.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        public ICollection<UserViewModel> Convert(ICollection<UserModel> users)
            => users?.Select(user => new UserViewModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id
            }).ToList();

        /// <summary>
        /// Converts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public CreateUserInputModel Convert(CreateUserInputViewModel user)
            => new CreateUserInputModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
            };

        /// <summary>
        /// Converts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public UpdateUserInputModel Convert(UpdateUserInputViewModel user)
        {
            return new UpdateUserInputModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,

            };
        }

        /// <summary>
        /// Converts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public UpdateUserInputViewModel Convert(UserModel user)
        {
            return new UpdateUserInputViewModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id
            };
        }

    }
}