﻿using System;

namespace Dna
{
    /// <summary>
    /// Handles exceptions when they are caught and passed to the exception handler
    /// </summary>
    public interface IExceptionHandler
    {
        /// <summary>
        /// Handles the given exception
        /// </summary>
        /// <param name="exception"></param>
        void HandleError(Exception exception);
    }
}
