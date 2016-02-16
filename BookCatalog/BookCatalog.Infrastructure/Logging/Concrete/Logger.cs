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
    public class Logger : ILogger
    {
        /// <summary>
        /// Logs exception in file.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        public void Log(Exception exception)
        {
            string logFileAddress = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/" + ConfigurationManager.AppSettings["LogFileName"];

            using (StreamWriter logFile = File.AppendText(logFileAddress))
            {
                logFile.WriteLine("------------------------------------------------------------------------");
                logFile.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                logFile.WriteLine("Error message:");
                logFile.WriteLine(exception.Message);
                logFile.WriteLine("Stack trace:");
                logFile.WriteLine(exception.StackTrace);
                if (exception.InnerException != null)
                {
                    logFile.WriteLine("-----Inner Exception:-----");
                    logFile.WriteLine("Error message:");
                    logFile.WriteLine(exception.InnerException.Message);
                    logFile.WriteLine("Stack trace:");
                    logFile.WriteLine(exception.InnerException.StackTrace);
                }

                logFile.WriteLine("------------------------------------------------------------------------");
            }
        }
    }
}