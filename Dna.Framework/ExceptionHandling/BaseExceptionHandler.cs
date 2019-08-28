using System;

namespace Dna
{
    /// <summary>
    /// Handles all exceptions, simply ogging them to the logger
    /// </summary>
    public class BaseExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Logs the given exeption
        /// </summary>
        /// <param name="exception">The exception</param>
        public void HandleError(Exception exception)
        {
            // Log it
            // TODO: Localization of strings
            Framework.Logger.LogCriticalSource("Unhandled exception occurred", exception: exception);
        }
    }
}
