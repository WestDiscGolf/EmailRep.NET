namespace EmailRep.NET
{
    /// <summary>
    /// Email Rep Configuration Exception. This exception is raised during configuration settings checking.
    /// </summary>
    public class EmailRepConfigurationException : EmailRepException
    {
        /// <summary>
        /// Constructor of a <see cref="EmailRepConfigurationException"/>. This exception is raised
        /// if there is any issue with the configuration of the client.
        /// </summary>
        /// <param name="message">Error message</param>
        public EmailRepConfigurationException(string message) : base(message)
        {
        }
    }
}