namespace NET.Utilities.Helpers
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    /// Summary:
    ///     A collection of singleton factory methods to help create singleton objects.
    ///     ** This class contains a dependacy to Microsoft.Extensions.DependencyInjection.
    public static class SingletonFactory<T>
    {
        private static readonly object _lock = new object();

        private static T _instance;

        public static T CreateInstance(params object[] args)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {   
                        _instance = (T) Activator.CreateInstance(typeof(T), args);
                    }
                }
            }

            return _instance;
        }

        public static T CreateInstance(IServiceProvider serviceProvider)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {   
                        _instance = (T) ActivatorUtilities.CreateInstance(serviceProvider, typeof(T));
                    }
                }
            }

            return _instance;
        }
    }
}