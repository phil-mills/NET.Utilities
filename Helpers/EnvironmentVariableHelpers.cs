namespace NET.Utilities.Helpers
{
    using System;
    using NET.Utilities.Extensions;

    /// Summary:
    ///     A collection of environment variable helper methods.
    public static class EnvironmentVariableHelpers
    {
        public static bool SetValue(string key, string value)
        {
            if (key.IsNullOrEmpty())
            {
                throw new InvalidOperationException("key can not be null or empty");
            }

            if (value.IsNullOrEmpty())
            {
                throw new InvalidOperationException("value can not be null or empty");
            }

            Environment.SetEnvironmentVariable(key, value);

            return EnvironmentVariableHelpers.HasValue(key);
        }

        public static string GetValue(string key)
        {
            if (key.IsNullOrEmpty())
            {
                throw new InvalidOperationException("key can not be null or empty");
            }

            return Environment.GetEnvironmentVariable(key);
        }

        public static bool HasValue(string key)
        {
            if (key.IsNullOrEmpty())
            {
                throw new InvalidOperationException("key can not be null or empty");
            }

            return Environment.GetEnvironmentVariable(key) != null;
        }

        public static bool DeleteValue(string key)
        {
            if (key.IsNullOrEmpty())
            {
                throw new InvalidOperationException("key can not be null or empty");
            }

            Environment.SetEnvironmentVariable(key, null, EnvironmentVariableTarget.Process);

            return !EnvironmentVariableHelpers.HasValue(key);
        }
    }
}