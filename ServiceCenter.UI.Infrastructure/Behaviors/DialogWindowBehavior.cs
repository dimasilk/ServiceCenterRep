using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceCenter.UI.Infrastructure.Behaviors
{
    public static class DialogWindowBehavior
    {
        public static readonly DependencyProperty DialogResultProperty = DependencyProperty.RegisterAttached("DialogResult", typeof(bool?), typeof(DialogWindowBehavior),
                new PropertyMetadata(DialogResultChanged));

        private static void DialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window != null && window.IsLoaded)
                window.DialogResult = e.NewValue as bool?;
        }
        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }

        public static readonly DependencyProperty DialogResultDataProperty = DependencyProperty.RegisterAttached("DialogResultData", typeof(object), typeof(DialogWindowBehavior), new PropertyMetadata());

        public static void SetDialogResultData(Window target, object value)
        {
            target.SetValue(DialogResultDataProperty, value);
        }

        public static object GetDialogResultData(Window target)
        {
            return target.GetValue(DialogResultDataProperty);
        }
    }
}
