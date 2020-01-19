using System;
using System.Threading.Tasks;

namespace EmailRep.NET.Mappers
{
    internal class DateMapper
    {
        public static Task<DateTimeOffset> MapAsync(string source)
        {
            return Task.FromResult(new DateTimeOffset());
        }
    }
}