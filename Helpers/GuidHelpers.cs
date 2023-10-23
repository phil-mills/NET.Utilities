namespace NET.Utilities.Helpers
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// Summary:
    ///     A collection of guid helper methods.
    public static class GuidHelpers
    {
        public static Guid FromBase64String(string guid)
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

        public static Guid ToGuid(string s)
        {
            using (MD5 md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(s));

                return new Guid(hash);
            }
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