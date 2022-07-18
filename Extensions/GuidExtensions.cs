namespace NET.Utilities.Extensions
{
    using System;

    /// Summary:
    ///     A collection of guid extension methods.
    public static class GuidExtensions
    {
        public static bool IsValid(this Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
