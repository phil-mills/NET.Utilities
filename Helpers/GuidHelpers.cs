namespace NET.Utilities.Helpers
{
    using System;

    /// Summary:
    ///     A collection of guid helper methods.
    public static class GuidHelpers
    {
        public static Guid ToGuid(string guid)
        {
            if (guid.Length != 22)
            {
                throw new ArgumentOutOfRangeException();
            }

            guid = guid.Replace("_", "/")
                 .Replace("-", "+");

            byte[] bytes = Convert.FromBase64String(guid + "==");

            return new Guid(bytes);
        }

        public static string ToBase64String(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                throw new NullReferenceException();
            }

            var shortGuid = Convert.ToBase64String(guid.ToByteArray())
                .Replace("/", "_")
                .Replace("+", "-");

            return shortGuid.Substring(0, 22);
        }
    }
}