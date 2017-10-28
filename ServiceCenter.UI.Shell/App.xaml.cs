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
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
            new ServiceCenterBootstrapper().Run();
        }
    }
}
