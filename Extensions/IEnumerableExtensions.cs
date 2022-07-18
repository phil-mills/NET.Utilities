namespace NET.Utilities.Extensions
{
    using System;
    using System.Collections.Generic;

    /// Summary:
    ///     A collection of ienumerable extension methods.
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach(T item in enumerable)
            {
                action(item);
            }
        }
    }
}