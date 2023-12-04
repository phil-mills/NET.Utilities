namespace NET.Utilities.Extensions
{
    using System;
    using System.Text.RegularExpressions;

    /// Summary:
    ///     A collection of string extension methods.
    public static class StringExtensions
    {
        public static bool IsNull(this string s)
        { 
            return s == null;
        }

        public static string NullIfEmpty(this string s)
        {
            return string.IsNullOrEmpty(s) ? null : s;
        }

        public static bool IsNullOrEmpty(this string s)
        { 
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNullOrWhiteSpace(this string s)
        { 
            return string.IsNullOrWhiteSpace(s);
        }

        public static bool HasValue(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        public static string ReplaceByExpression(this string s, string expression, string replacement)
        {
            if (expression.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException();
            }

            if (replacement.IsNull())
            {
                throw new ArgumentNullException();
            }

            return Regex.Replace(s, expression, replacement);
        }

        public static int GetWordCount(this string s)
        {
            Regex regex = new Regex("\\w+");
 
            int words = regex.Matches(s).Count;
 
            return words;
        }
    }
}