using System;
using System.Windows;

namespace ServiceCenter.UI.Shell
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            new ServiceCenterBootstrapper().Run();
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(MainWindow, e.Exception.Message);
        }
        
    }
}
