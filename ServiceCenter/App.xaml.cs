using System.Windows;
using Microsoft.Practices.Unity;

namespace ServiceCenter
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();

            //container.RegisterType<interface, class>();
           

            //var mainWindow = container.Resolve<MainWindow>(); // Creating Main window
            //mainWindow.Show();

        }
    }
}
