﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xaml;

namespace ServiceCenter.UI.Infrastructure.Behaviors
{
    public static class MouseDoubleClickCommandBehaviour
    {
        #region DependencyProperty
        public static readonly DependencyProperty DoubleClickCommandParameterProperty =
            DependencyProperty.RegisterAttached("DoubleClickCommandParameter", typeof(object), typeof(MouseDoubleClickCommandBehaviour));


        public static object GetDoubleClickCommandParameter(DependencyObject d)
        {
            return (object)d.GetValue(DoubleClickCommandParameterProperty);
        }

        public static void SetDoubleClickCommandParameter(DependencyObject d, object value)
        {
            d.SetValue(DoubleClickCommandParameterProperty, value);
        }

        public static readonly DependencyProperty DoubleClickCommandProperty = 
            DependencyProperty.RegisterAttached("DoubleClickCommand", typeof(ICommand), typeof(MouseDoubleClickCommandBehaviour), new FrameworkPropertyMetadata(OnCommandPropertyChanged));


        public static ICommand GetDoubleClickCommand(DependencyObject d)
        {
            return (ICommand) d.GetValue(DoubleClickCommandProperty);
        }

        public static void SetDoubleClickCommand(DependencyObject d, object value)
        {
            d.SetValue(DoubleClickCommandProperty, value);
        }
        #endregion
        private static void OnCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            FrameworkElement element = d as FrameworkElement;
            if (element == null) return;
            element.MouseDown -= Element_MouseDown;
            if (args.NewValue != null) element.MouseDown += Element_MouseDown;
        }

        private static void Element_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement) sender;
            if (e.ClickCount != 2) return;
            var command = GetDoubleClickCommand(element);
            var par = GetDoubleClickCommandParameter(element);
            if (command == null || !command.CanExecute(par)) return;
            command.Execute(par);
            
        }

       
    }
}