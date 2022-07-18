namespace NET.Utilities.Helpers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;

    /// Summary:
    ///     A collection of reflection helper methods.
    ///     ** This class contains a dependacy to Microsoft.Extensions.DependencyInjection.
    public static class ReflectionHelpers
    {
        public static IEnumerable<Type> GetImplementations<T>()
        where T : class
        {
            var type = typeof(T);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                                 .SelectMany(s => s.GetTypes())
                                 .Where(p => type.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);

            return types;
        }

        public static IEnumerable<T> CreateInstances<T>(IServiceProvider serviceProvider)
        where T : class
        {
            List<T> createdInstances = new List<T>();

            var types = ReflectionHelpers.GetImplementations<T>();

            foreach(var type in types)
            {
                createdInstances.Add((T) ActivatorUtilities.CreateInstance(serviceProvider, type));
            }

            return createdInstances;
        }
    }
}