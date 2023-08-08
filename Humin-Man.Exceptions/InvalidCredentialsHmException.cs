using System;
using System.Collections.Generic;
using System.Text;

namespace Humin_Man.Exceptions
{
    /// <summary>
    /// Exception thrown when user credentials are invalid.
    /// </summary>
    /// <seealso cref="Humin_Man.Exceptions.HmException" />
    public class InvalidCredentialsHmException : HmException
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Identifier { get; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCredentialsHmException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="identifier">The identifier.</param>
        /// <param name="password">The password.</param>
        public InvalidCredentialsHmException(string message, string identifier, string password) : base(message)
        {
            Identifier = identifier;
            Password = password;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCredentialsHmException"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="password">The password.</param>
        public InvalidCredentialsHmException(string identifier, string password) : this("Invalid user credentials.", identifier, password)
        { }
    }
}
