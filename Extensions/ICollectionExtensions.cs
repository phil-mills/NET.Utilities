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
    }
}