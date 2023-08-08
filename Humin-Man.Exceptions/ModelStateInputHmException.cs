using System.Collections.Generic;

namespace Humin_Man.Exceptions
{
    /// <summary>
    /// Rxception thrown when model input failed validation.
    /// </summary>
    /// <seealso cref="Humin_Man.Exceptions.HmException" />
    public class ModelStateInputHmException : HmException
    {
        /// <summary>
        /// Gets the model errors.
        /// </summary>
        /// <value>
        /// The model errors.
        /// </value>
        public ICollection<string> ModelErrors { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelStateInputHmException"/> class.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <param name="message">The message.</param>
        public ModelStateInputHmException(ICollection<string> errors, string message) : base(message)
        {
            ModelErrors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelStateInputHmException"/> class.
        /// </summary>
        /// <param name="errors">The errors.</param>
        public ModelStateInputHmException(ICollection<string> errors) : this(errors, $"Model state validation failed with errors {errors}")
        { }
    }
}
