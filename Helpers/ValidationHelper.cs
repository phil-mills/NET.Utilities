using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NET.Utilities.Helpers
{
    public static class ValidationHelper
    {
        public static bool ValidateEntity(object obj)
        {
            var results = new List<ValidationResult>();
            
            return ValidationHelper.ValidateEntity(obj, results);
        }

        public static bool ValidateEntity(object obj, out List<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            
            return ValidationHelper.ValidateEntity(obj, results);
        }
        
        private static bool ValidateEntity(object obj, List<ValidationResult> results)
        {
            var isValid = true;
            var properties = obj.GetType().GetProperties();

            foreach(var prop in properties)
            {
                var context = new ValidationContext(obj);
                context.MemberName = prop.Name;

                isValid &= Validator.TryValidateProperty(prop.GetValue(obj), context, results);

                if (prop.GetValue(obj) != null && !prop.PropertyType.IsPrimitive)
                {
                    isValid &= ValidationHelper.ValidateEntity(prop.GetValue(obj), results);
                }
            }

            return isValid;
        }
    }
}