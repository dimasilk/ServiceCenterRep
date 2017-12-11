using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ServiceCenter.UI.Infrastructure.Behaviors
{
    public static class TextChangedCommandBehavior
    {

        #region DependencyProperty

        public static readonly DependencyProperty TextChangedCommandProperty =
            DependencyProperty.RegisterAttached("TextChangedCommand", typeof(ICommand), typeof(TextChangedCommandBehavior), new FrameworkPropertyMetadata(OnCommandPropertyChanged));


        public static ICommand GetTextChangedCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(TextChangedCommandProperty);
        }

        public static void SetTextChangedCommand(DependencyObject d, object value)
        {
            d.SetValue(TextChangedCommandProperty, value);
        }
        #endregion
        private static void OnCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            FrameworkElement element = d as FrameworkElement;
            if (element == null) return;
            element.RemoveHandler(TextBoxBase.TextChangedEvent, (RoutedEventHandler)OnTextChanged);
            if (args.NewValue != null)
                element.AddHandler(TextBoxBase.TextChangedEvent, (RoutedEventHandler)OnTextChanged, true);
        }

        private static void OnTextChanged(object sender, RoutedEventArgs args)
        {
            FrameworkElement element = (FrameworkElement)sender;
            
            var command = GetTextChangedCommand(element);
            var textbox = args.OriginalSource as TextBox;
            if (command == null || textbox == null || !command.CanExecute(textbox.Text)) return;
            command.Execute(textbox.Text);
        }
       
    }
}
