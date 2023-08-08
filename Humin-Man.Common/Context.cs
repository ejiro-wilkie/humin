namespace Humin_Man.Common
{
    /// <summary>
    /// Class that implements <see cref="IContext"/>.
    /// </summary>
    /// <seealso cref="Humin_Man.Common.IContext" />
    public class Context : IContext
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public long UserId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public Context(long userId)
        {
            UserId = userId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// </summary>
        public Context() { }
    }
}
