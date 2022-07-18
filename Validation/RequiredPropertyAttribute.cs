namespace NET.Utilities.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    /// Summary:
    ///     This class is designed to validate if a property exists within an object.
    ///         eg: JToken.Value. 
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequiredPropertyAttribute : RequiredAttribute
    {
        private string property;

        public RequiredPropertyAttribute(string property)
        {
            this.property = property;
        }

        public override bool IsValid(object value)
        {
            var result = base.IsValid(value);
            
            if (result)
            {
                foreach (var prop in value.GetType().GetProperties())
                {
                    if (prop.Name == property)
                    {
                        return prop.GetValue(value) != null;
                    }
                }

                throw new MissingFieldException($"Failed to find {property}");
            }

            return result;
        }
    }
}