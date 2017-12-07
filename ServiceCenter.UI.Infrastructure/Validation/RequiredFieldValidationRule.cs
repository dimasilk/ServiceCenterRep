using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ServiceCenter.UI.Infrastructure.Validation
{
    public class RequiredFieldValidationRule : ValidationRule
    {
        public string Field { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty((string) value)) return new ValidationResult(false, "Field " + Field + " is required");
            return new ValidationResult(true, null);
        }
    }
}
