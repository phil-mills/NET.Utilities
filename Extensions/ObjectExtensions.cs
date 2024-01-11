namespace NET.Utilities.Extentions
{
    using System;
    using System.Reflection;

    /// Summary:
    ///     A collection of object extension methods.
    public static class ObjectExtensions
    {
        public static void PropertyIterator(this object obj, Action<PropertyInfo, object> action)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                if  (prop.GetValue(obj) != null && prop.PropertyType.IsClass
                     && !prop.PropertyType.Namespace.StartsWith("System"))
                {
                    ObjectExtensions.PropertyIterator(prop.GetValue(obj), action);
                }

                action(prop, obj);
            }
        }

        public static bool HasProperty(this object obj, string name)
        {
            return obj.GetType().GetProperty(name) != null;
        }

        public static T MapProperties<T>(this object obj)
        where T : class, new()
        {
           var destination = new T();

            obj.PropertyIterator((p,o) => 
            {
                var destProp = destination.GetType().GetProperty(p.Name);
                destProp.SetValue(destination, p.GetValue(o));   
            });

             return destination;
        }

        public static string ParseAny(this object obj)
	    {
    		if (obj == null)
    		{
    			return string.Empty;
    		}
    		
    	    return obj.ToString();
	    }
    }
}
