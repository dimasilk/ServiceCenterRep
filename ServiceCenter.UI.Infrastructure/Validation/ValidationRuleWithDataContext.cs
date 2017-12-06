using System;
using System.Globalization;
using System.Windows.Controls;

namespace ServiceCenter.UI.Infrastructure.Validation
{
    public class ValidationRuleWithDataContext : ValidationRule
    {
        private WeakReference _dataContext;

        public object DataContext
        {
            get { return _dataContext.Target; }
            set { _dataContext = new WeakReference(value); }
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
