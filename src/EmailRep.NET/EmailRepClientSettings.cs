namespace EmailRep.NET
{
    /// <summary>
    /// Configuration settings POCO for the Email Rep .NET client.
    /// </summary>
    public class EmailRepClientSettings
    {
        /// <summary>
        /// BaseUrl for the email rep api. Default: https://emailrep.io/
        /// </summary>
        public string BaseUrl { get; set; } = "https://emailrep.io/";

        /// <summary>
        /// Request UserAgent. A specific user agent is required for making requests to the email rep api.
        /// </summary>
        public string UserAgent { get; set; } = "test/development";

        /// <summary>
        /// ApiKey. This is optional.
        /// </summary>
        /// <remarks>
        /// Without an Api key value the number and type of request possible is limited in scope.
        /// </remarks>
        public string ApiKey { get; set; }

        /// <summary>
        /// Default settings static property.
        /// </summary>
        public static EmailRepClientSettings Default = new EmailRepClientSettings();
    }
}