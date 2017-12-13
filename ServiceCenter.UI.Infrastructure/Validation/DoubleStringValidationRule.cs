using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ServiceCenter.UI.Infrastructure.Validation
{
    public class DoubleStringValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = String.Empty;
            try
            {
                str = (string)value;
            }
            catch
            {
                return new ValidationResult(false, "Coefficient validation error");
            }

            if (string.IsNullOrEmpty(str))
            {
                return new ValidationResult(false, "Coefficient was not entered");
            }
           
            try
            {
                var x = double.Parse(str);
            }
            catch
            {
                return new ValidationResult(false, "Coefficient should be double type");
            }

            return new ValidationResult(true, null);
        }
    }
}
