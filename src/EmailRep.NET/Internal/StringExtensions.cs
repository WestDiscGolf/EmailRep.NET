namespace EmailRep.NET.Internal
{
    internal static class StringExtensions
    {
        public static string IsValidEmail(this string value) => string.IsNullOrWhiteSpace(value) ? null : value;
    }
}