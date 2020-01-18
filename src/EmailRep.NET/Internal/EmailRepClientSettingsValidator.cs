using System;

namespace EmailRep.NET.Internal
{
    internal class EmailRepClientSettingsValidator
    {
        public static void Validate(EmailRepClientSettings settings)
        {
            // check that the settings are not null as settings are required
            _ = settings ?? throw new ArgumentNullException($"{nameof(EmailRepClientSettings)} can not be null.");

            // must have a base url so we'd better check for one
            if (string.IsNullOrWhiteSpace(settings.BaseUrl))
            {
                throw new EmailRepConfigurationException($"{nameof(EmailRepClientSettings.BaseUrl)} can not be empty.");
            }
        }
    }
}