using System;

namespace Humin_Man.Exceptions
{
    /// <summary>
    /// Class that represent the humin-Man base exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class HmException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HmException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public HmException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HmException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<see langword="Nothing" /> in Visual Basic) if no inner exception is specified.</param>
        public HmException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
