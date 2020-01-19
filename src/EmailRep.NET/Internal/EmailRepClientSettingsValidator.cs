using System;

namespace EmailRep.NET.Internal
{
    /// <summary>
    /// Internal settings validator.
    /// </summary>
    internal class EmailRepClientSettingsValidator
    {
        /// <summary>
        /// The settings required to call emailrep.io need some specifc items and this validates the settings instance to make sure the required values are set.
        /// It does not check that the values in the properties are valid, just that there are values present.
        /// </summary>
        /// <param name="settings"></param>
        public static void Validate(EmailRepClientSettings settings)
        {
            // check that the settings are not null as settings are required
            _ = settings ?? throw new ArgumentNullException($"{nameof(EmailRepClientSettings)} can not be null. Please check your configuration.");

            // must have a base url so we'd better check for one
            if (string.IsNullOrWhiteSpace(settings.BaseUrl))
            {
                throw new EmailRepConfigurationException($"{nameof(EmailRepClientSettings.BaseUrl)} can not be empty. Please check your configuration.");
            }

            if (string.IsNullOrWhiteSpace(settings.UserAgent))
            {
                throw new EmailRepConfigurationException($"{nameof(EmailRepClientSettings.UserAgent)} can not be empty. Please check your configuration.");
            }
        }
    }
}