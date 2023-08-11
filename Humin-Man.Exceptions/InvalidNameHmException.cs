namespace Humin_Man.Exceptions
{
    /// <summary>
    /// Exception thrown when the shop name doesn't match the requirement.
    /// </summary>
    /// <seealso cref="Humin_Man.Exceptions.HmException" />
    public class InvalidNameHmException : HmException
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidNameHmException"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public InvalidNameHmException(string name) : this($"The shop name: {name} must not be less than 5 characters nor more than 10", name)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidNameHmException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="name">The name.</param>
        public InvalidNameHmException(string message, string name) : base(message)
        {
            Name = name;
        }
    }
}
