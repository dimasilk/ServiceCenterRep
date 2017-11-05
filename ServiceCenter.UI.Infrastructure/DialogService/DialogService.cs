using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ServiceCenter.UI.Infrastructure.Behaviors;

namespace ServiceCenter.UI.Infrastructure.DialogService
{
    public interface IDialogService
    {
        bool? ShowDialog<T>(string title, out object result) where T : Window, new();
    }
    public class DialogService : IDialogService
    {
        public bool? ShowDialog<T>(string title, out object result) where T : Window, new()
        {
            var window = new T();
            if (!string.IsNullOrWhiteSpace(title))
            {
                window.Title = title;
            }
            window.ShowInTaskbar = false;
            window.ResizeMode = ResizeMode.NoResize;
            window.Owner = Application.Current.MainWindow;
            window.Closed += Window_Closed;
            var dialogResult = window.ShowDialog();
            result = DialogWindowBehavior.GetDialogResultData(window);
            window.ClearValue(DialogWindowBehavior.DialogResultDataProperty);

            return dialogResult;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var window = (Window)sender;
            window.Closed -= Window_Closed;
            var disposable = window.DataContext as IDisposable;
            disposable?.Dispose();
        }
    }
}
