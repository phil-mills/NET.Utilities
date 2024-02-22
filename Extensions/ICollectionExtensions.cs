namespace NET.Utilities.Extensions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    /// Summary:
    ///     A collection of icollection extension methods.
    public static class ICollectionExtensions
    {
        public static T Pick<T>(this ICollection<T> items)
        {
            Random random = new Random();
            
            int index = random.Next(items.Count);

            return items.ElementAt(index);
        }

        public static IEnumerable<IEnumerable<T>> Partition<T>(this ICollection<T> values, int chunkSize)
        {
            return values.Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList());
        }

        public static (ICollection<T> left, ICollection<T> right) SymmetricDifference<T>(this ICollection<T> values, ICollection<T> other)
        {
            var left = values.Except(other).ToList();
            var right = other.Except(values).ToList();

            return (left, right);
        }
    }
}