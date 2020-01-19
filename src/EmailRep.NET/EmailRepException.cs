using System;

namespace EmailRep.NET
{
    /// <summary>
    /// Email Rep Exception. This exception is the base exception for the emailrep.io library.
    /// </summary>
    public class EmailRepException : Exception
    {
        public EmailRepException(string message) : base(message)
        {
        }
    }
}