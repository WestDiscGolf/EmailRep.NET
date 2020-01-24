using System;
using System.Globalization;
using System.Threading.Tasks;

namespace EmailRep.NET.Mappers
{
    /// <summary>
    /// Date mapper
    /// </summary>
    internal class DateMapper
    {
        /// <summary>
        /// Maps the source mm/dd/yyyy provided by the email rep api and converts it into <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Task<DateTimeOffset> MapAsync(string source) => Task.FromResult(DateTimeOffset.TryParse(source, CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.None, out var converted) ? converted : DateTimeOffset.MinValue);
    }
}