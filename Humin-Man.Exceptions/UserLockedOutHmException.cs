namespace Humin_Man.Exceptions
{
    /// <summary>
    /// Exception throwm when the user is locked out.
    /// </summary>
    /// <seealso cref="Humin_Man.Exceptions.HmException" />
    public class UserLockedOutHmException : HmException
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Identifier { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLockedOutHmException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="identifier">The identifier.</param>
        public UserLockedOutHmException(string message, string identifier) : base(message)
        {
            Identifier = identifier;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLockedOutHmException"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        public UserLockedOutHmException(string identifier) : this($"User {identifier} is locked out.", identifier)
        { }
    }
}
