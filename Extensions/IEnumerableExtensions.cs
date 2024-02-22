namespace NET.Utilities.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// Summary:
    ///     A collection of ienumerable extension methods.
    public static class IEnumerableExtensions
    {
        public static T Pick<T>(this IEnumerable<T> items)
        {
            Random random = new Random();
            
            int index = random.Next(items.Count());

            return items.ElementAt(index);
        }

        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> values, int chunkSize)
        {
            return values.Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value));
        }
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach(T item in enumerable)
            {
                action(item);
            }
        }

        public static (IEnumerable<T> Left, IEnumerable<T> Right) SymmetricDifference<T>(this IEnumerable<T> values, IEnumerable<T> other)
        {
            var left = values.Except(other);
            var right = other.Except(values);

            return (left, right);
        }
    }
}