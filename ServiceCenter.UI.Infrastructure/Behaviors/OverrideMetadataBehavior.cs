using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ServiceCenter.UI.Infrastructure.Validation;

namespace ServiceCenter.UI.Infrastructure.Behaviors
{
    public static class OverrideMetadataBehavior
    {
        public static void Override()
        {
            FrameworkElement.DataContextProperty.OverrideMetadata(typeof(TextBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
        }

        private static void Initialize(TextBox t)
        {
            var binding = t.GetBindingExpression(TextBox.TextProperty);
            if (binding?.ParentBinding == null) return;
            var rules = binding.ParentBinding.ValidationRules.OfType<ValidationRuleWithDataContext>().ToArray();
            foreach (var r in rules)
            {
                r.DataContext = t.DataContext;
            }
        }

        private static void OnTextBoxDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            TextBox t = (TextBox) d;
            if (t.IsInitialized) Initialize(t);
            else t.Initialized += Initialized;
        }

        private static void Initialized(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.Initialized -= Initialized;
            Initialize(t);
        }
    }
}
