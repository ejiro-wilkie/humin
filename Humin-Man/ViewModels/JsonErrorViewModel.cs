namespace Humin_Man.ViewModels
{
    /// <summary>
    /// Class that represents a json error.
    /// </summary>
    public class JsonErrorViewModel
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonErrorViewModel"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public JsonErrorViewModel(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{nameof(Message)}:[{Message}]";
    }
}
