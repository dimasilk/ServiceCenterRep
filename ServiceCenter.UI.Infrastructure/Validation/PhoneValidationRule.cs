using System;
using System.Globalization;
using System.Windows.Controls;

namespace ServiceCenter.UI.Infrastructure.Validation
{
    public class PhoneValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string phone = String.Empty;
            try
            {
                phone = (string)value;
            }
            catch
            {
                return new ValidationResult(false, "Phone number validation error");
            }

            if (string.IsNullOrEmpty(phone))
            {
                return new ValidationResult(false, "Phone number was not entered");
            }
            if (phone.Contains("_"))
            {
                return new ValidationResult(false, "phone number was not entered completely");
            }

            return new ValidationResult(true, null);
            
        }
    }
    
}
