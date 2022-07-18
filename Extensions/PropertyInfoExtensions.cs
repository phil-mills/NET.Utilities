namespace NET.Utilities.Extensions
{
    using System.Reflection;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// Summary:
    ///     A collection of property info extension methods.
    public static class PropertyInfoExtensions
    {
        public static bool IsPropertyValid(this PropertyInfo prop, object obj, ICollection<ValidationResult> validationResults)
        {   
            var validationContext = new ValidationContext(obj);
            validationContext.MemberName = prop.Name;

            return Validator.TryValidateProperty(prop.GetValue(obj), validationContext, validationResults);
        }
    }
}