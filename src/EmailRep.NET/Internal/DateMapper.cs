﻿using System;
using System.Threading.Tasks;

namespace EmailRep.NET.Internal
{
    internal class DateMapper
    {
        public static Task<DateTimeOffset> MapAsync(string source)
        {
            return Task.FromResult(new DateTimeOffset());
        }
    }
}