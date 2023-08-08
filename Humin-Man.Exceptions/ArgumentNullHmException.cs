namespace Humin_Man.Exceptions
{
    /// <summary>
    /// Exception thrown when the argument is null
    /// </summary>
    /// <seealso cref="Humin_Man.Exceptions.HmException" />
    public class ArgumentNullHmException : HmException
    {
        /// <summary>
        /// Gets or sets the obkect.
        /// </summary>
        /// <value>
        /// The obkect.
        /// </value>
        public string Object { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentNullHmException"/> class.
        /// </summary>
        /// <param name="objectName">Name of the object.</param>
        /// <param name="message">The message.</param>
        public ArgumentNullHmException(string objectName, string message) : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentNullHmException"/> class.
        /// </summary>
        /// <param name="objectName">Name of the object.</param>
        public ArgumentNullHmException(string objectName) : this(objectName, $"No object was provided for {objectName}")
        {
            Object = objectName;
        }
    }
}
