using System;
using System.Threading;
using System.Windows;
using Microsoft.Practices.Unity;
using ServiceCenter.UI.Infrastructure.Behaviors;

namespace ServiceCenter.UI.Infrastructure.DialogService
{
    public interface IDialogService
    {
        bool? ShowDialog<T, TResult>(string title, out TResult result, params ResolverOverride[] parametrs) where T : Window where TResult : class;
        bool? ShowDialog<T>(string title, params ResolverOverride[] parametrs) where T : Window;
    }
    public class DialogService : IDialogService
    {
        private readonly IUnityContainer _container;

        public DialogService(IUnityContainer container)
        {
            _container = container;
        }

        public bool? ShowDialog<T, TResult>(string title, out TResult result, params ResolverOverride[] parametrs) where T : Window where TResult : class
        {
            var window = _container.Resolve<T>(parametrs);
            if (!string.IsNullOrWhiteSpace(title))
            {
                window.Title = title;
            }
            window.ShowInTaskbar = false;
            window.ResizeMode = ResizeMode.NoResize;
            window.Closed += Window_Closed;
            var dialogResult = window.ShowDialog();
            result = DialogWindowBehavior.GetDialogResultData(window) as TResult;
            window.ClearValue(DialogWindowBehavior.DialogResultDataProperty);

            return dialogResult;
        }

        public bool? ShowDialog<T>(string title, params ResolverOverride[] parametrs) where T : Window
        {
            object obj;
            return ShowDialog<T, object>(title, out obj, parametrs);
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
