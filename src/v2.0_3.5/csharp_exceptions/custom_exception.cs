/*
 *    Filename: <custom_exception.cs>
 *
 * Description: Customizing exceptions
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.Exceptions
{
    public class CPUOverclockException : ApplicationException
    {
        public new string Message { get; set; }
        public string Cause { get; set; }
        public DateTime Timestamp { get; set; }

        public CPUOverclockException(string message, string cause, DateTime timestamp)
        {
            this.Timestamp = timestamp;
            this.Cause = cause;
            this.Message = string.Format("CPUOverclockException: {0}", message);
        }
    }
}