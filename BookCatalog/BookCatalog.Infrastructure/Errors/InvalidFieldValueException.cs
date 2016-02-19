namespace BookCatalog.Infrastructure.Errors
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Exception for invalid field.
    /// </summary>
    public class InvalidFieldValueException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFieldValueException"/> class.
        /// </summary>
        public InvalidFieldValueException()
        {
            this.ValidationMessage = string.Empty;
            this.Field = string.Empty;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFieldValueException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public InvalidFieldValueException(string message) : base(message)
        {
            this.ValidationMessage = message;
            this.Field = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFieldValueException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="field">Field name.</param>
        public InvalidFieldValueException(string message, string field) : base(message)
        {
            this.ValidationMessage = message;
            this.Field = field;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFieldValueException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="field">Field name.</param>
        /// <param name="innerException">Inner exception.</param>
        public InvalidFieldValueException(string message, string field, Exception innerException) : base(message, innerException)
        {
            this.ValidationMessage = message;
            this.Field = field;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFieldValueException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner exception.</param>
        public InvalidFieldValueException(string message, Exception innerException) : base(message, innerException)
        {
            this.ValidationMessage = message;
            this.Field = string.Empty;
        }

        /// <summary>
        /// Gets field name.
        /// </summary>
        public string Field { get; private set; }

        /// <summary>
        /// Gets validation message.
        /// </summary>
        public string ValidationMessage { get; private set; }
    }
}
