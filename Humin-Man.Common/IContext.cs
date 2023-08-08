namespace Humin_Man.Common
{
    /// <summary>
    /// Class that defines the user context for each request.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        long UserId { get; }
    }
}
