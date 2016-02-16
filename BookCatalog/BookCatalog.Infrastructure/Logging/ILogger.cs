namespace BookCatalog.Infrastructure.Logging
{
    #region Using

    using System;

    #endregion

    /// <summary>
    /// Logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs exception.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        void Log(Exception exception);
    }
}