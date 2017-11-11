using System;
using System.ServiceModel;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.UI.Infrastructure.DialogService;
using ServiceCenter.UI.Infrastructure.Interfaces;
using ServiceCenter.UI.Shell.Login;

namespace ServiceCenter.UI.Shell
{
    public class ServiceCenterBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            Authentificate();
            Application.Current.MainWindow = this.Container.Resolve<Shell>();
            return Application.Current.MainWindow;
        }

        private void Authentificate()
        {
            var dialogService = Container.Resolve<IDialogService>();
            var loginDialogResult = dialogService.ShowDialog<LoginWindowView>(string.Empty);
            if (loginDialogResult != null && loginDialogResult.Value) return;
            Container.Dispose();
            Environment.Exit(1);
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IDialogService, DialogService>();
            var loginService = Container.Resolve<LoginService>();
            Container.RegisterInstance<ILoginService>(loginService);
            Container.RegisterInstance<ILoginSetCredentialsService>(loginService);
            Container.RegisterInstance(new ChannelFactory<IWcfLoginService>(nameof(IWcfLoginService)));
            Container.RegisterType<IWcfLoginService, LoginServiceClient>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

       
        
    }
}
