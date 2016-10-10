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
    public interface IInfoLogger
    {
        /// <summary>
        /// Logs.
        /// </summary>
        /// <param name="place">Where log occured.</param>
        /// <param name="message">Info message to log.</param>
        void Log(string place, string message);
    }
}