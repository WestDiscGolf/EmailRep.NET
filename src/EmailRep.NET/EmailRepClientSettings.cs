namespace EmailRep.NET
{
    public class EmailRepClientSettings
    {
        public string BaseUrl { get; set; } = "https://emailrep.io/";

        public string UserAgent { get; set; } = "test/development";

        public string ApiKey { get; set; }

        public static EmailRepClientSettings Default = new EmailRepClientSettings();
    }
}