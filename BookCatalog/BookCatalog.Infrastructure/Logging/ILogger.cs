//-----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.Infrastructure.Logging
{
    #region Using

    using System;

    #endregion

    /// <summary>
    /// Logger interface.
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