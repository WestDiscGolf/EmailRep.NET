namespace EmailRep.NET
{
    /// <summary>
    /// Email Rep Configuration Exception. This exception is raised during configuration settings checking.
    /// </summary>
    public class EmailRepConfigurationException : EmailRepException
    {
        public EmailRepConfigurationException(string message) : base(message)
        {
        }
    }
}