using Humin_Man.Common.Model.User;
using Humin_Man.Entities;

namespace Humin_Man.Converter
{
    /// <summary>
    /// Class that represents the user converter.
    /// </summary>
    public class UserConverter
    {
        public UserModel EntityToModel(User input)
        {
            if (input == null)
                return null;

            return new UserModel
            {
                Email = input.Email,
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.UserName,
                PhoneNumber = input.PhoneNumber,
                UpdatedAt = input.UpdatedAt,
                Id = input.Id
            };
        }
    }
}