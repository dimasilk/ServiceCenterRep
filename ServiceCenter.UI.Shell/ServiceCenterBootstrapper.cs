using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using ServiceCenter.UI.Infrastructure.DialogService;

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
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
        
    }
}
