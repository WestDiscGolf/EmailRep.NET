using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailRep.NET.Extensions.DependencyInjection
{
    /// <summary>
    /// ServiceCollection Extensions to setup the email rep registration
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add email rep client and register associated settings through configuration for the client.
        /// </summary>
        /// <param name="services">The instance of <see cref="IServiceCollection"/> on which the services are to be registered with.</param>
        /// <param name="configuration">The configuration section which contains the email rep configuration section.</param>
        /// <param name="sectionName">The configuration section name to use. Default: "EmailRepNet".</param>
        /// <returns></returns>
        public static IServiceCollection AddEmailRep(this IServiceCollection services, IConfiguration configuration, string sectionName = "EmailRepNet")
        {
            var settings = new EmailRepClientSettings();
            configuration.GetSection(sectionName).Bind(settings);
            services.AddSingleton(settings);

            services.AddHttpClient<IEmailRepClient, EmailRepClient>();
            return services;
        }
    }
}
