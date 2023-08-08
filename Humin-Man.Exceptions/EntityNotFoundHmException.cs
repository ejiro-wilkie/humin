namespace Humin_Man.Exceptions
{
    /// <summary>
    /// Exception thrown when an entity isn't found.
    /// </summary>
    /// <seealso cref="Humin_Man.Exceptions.HmException" />
    public class EntityNotFoundHmException : HmException
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public object Identifier { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundHmException"/> class.
        /// </summary>
        /// <param name="name">The message.</param>
        /// <param name="identifier">The identifier.</param>
        public EntityNotFoundHmException(string name, object identifier) : this($"No {name} was found with identifier : {identifier}",name, identifier)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundHmException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="name">The name.</param>
        /// <param name="identifier">The identifier.</param>
        public EntityNotFoundHmException(string message, string name, object identifier) : base(message)
        {
            Identifier = identifier;
            Name = name;
        }
    }
}
