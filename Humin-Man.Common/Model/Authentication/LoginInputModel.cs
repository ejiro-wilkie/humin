using System;
using System.Collections.Generic;
using System.Text;

namespace Humin_Man.Common.Model.Authentication
{
    /// <summary>
    /// Class that represents the login input model.
    /// </summary>
    public class LoginInputModel
    {

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{nameof(Email)}:[{Email}]|{nameof(Password)}:[{Password}]";
    }
}
