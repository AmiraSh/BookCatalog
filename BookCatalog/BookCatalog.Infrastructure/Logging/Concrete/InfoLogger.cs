//-----------------------------------------------------------------------
// <copyright file="InfoLogger.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.Infrastructure.Logging.Concrete
{
    #region Using

    using System;
    using System.Configuration;
    using System.IO;

    #endregion

    /// <summary>
    /// Logger for logging in file.
    /// </summary>
    public static class InfoLogger
    {
        /// <summary>
        /// Logs info message to file.
        /// </summary>
        /// <param name="place">Where log occured.</param>
        /// <param name="message">Info message to log.</param>
        public static void Log(string place, string message)
        {
            string logFileAddress = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/" + ConfigurationManager.AppSettings["InfoLogFileName"];

            using (StreamWriter logFile = File.AppendText(logFileAddress))
            {
                logFile.WriteLine("{0},{1},{2},{3}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), place, message);
            }
        }
    }
}