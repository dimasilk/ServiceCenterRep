using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ServiceCenter.UI.Infrastructure.Behaviors
{
    public static class LoaderBehavior
    {
        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.RegisterAttached("IsBusy", typeof(bool), typeof(LoaderBehavior), new FrameworkPropertyMetadata(OnIsBusyPropertyChanged));


        public static bool GetIsBusy(DependencyObject d)
        {
            return (bool)d.GetValue(IsBusyProperty);
        }

        public static void SetIsBusy(DependencyObject d, bool value)
        {
            d.SetValue(IsBusyProperty, value);
        }

        private static void OnIsBusyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var grid = d as Grid;
            if (grid == null) return;
            var progressBar = grid.Children.OfType<ProgressBar>().FirstOrDefault();
            if (progressBar == null)
            {
                progressBar = new ProgressBar
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 300,
                    IsIndeterminate = true
                };
                grid.Children.Add(progressBar);
            }
            var isBusy = (bool) args.NewValue;
            progressBar.Visibility = isBusy ? Visibility.Visible : Visibility.Collapsed;
            grid.IsEnabled = !isBusy;
            


        }
    }
}
