using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace ServiceCenter.UI.Shell
{
    public class ServiceCenterBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            Application.Current.MainWindow = this.Container.Resolve<Shell>();
            return Application.Current.MainWindow;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
        
    }
}
