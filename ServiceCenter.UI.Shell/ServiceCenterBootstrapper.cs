using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using ServiceCenter.UI.Infrastructure.DialogService;
using ServiceCenter.UI.Infrastructure.Interfaces;
using ServiceCenter.UI.Shell.Login;

namespace ServiceCenter.UI.Shell
{
    public class ServiceCenterBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            Application.Current.MainWindow = this.Container.Resolve<Shell>();
            return Application.Current.MainWindow;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IDialogService, DialogService>();
            Container.RegisterType<ILoginService, LoginService>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
        
    }
}
