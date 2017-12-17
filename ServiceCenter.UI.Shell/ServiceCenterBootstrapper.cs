using System;
using System.Configuration;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.UI.Infrastructure.Behaviors;
using ServiceCenter.UI.Infrastructure.DialogService;
using ServiceCenter.UI.Infrastructure.Interfaces;
using ServiceCenter.UI.Infrastructure.LogService;
using ServiceCenter.UI.Shell.Interfaces;
using ServiceCenter.UI.Shell.Login;
using SharpRaven;

namespace ServiceCenter.UI.Shell
{
    public class ServiceCenterBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
#if !DEBUG 
            Authentificate();
#endif
            var shell = this.Container.Resolve<Shell>();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            Application.Current.MainWindow = shell;
            shell.Show();
            OverrideMetadataBehavior.Override();
            return shell;
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
            Container.RegisterInstance<IUserIdService>(loginService);
            Container.RegisterType<IWcfLoginService, LoginServiceClient>(new ContainerControlledLifetimeManager());
            Container.RegisterInstance(new RavenClient(ConfigurationManager.AppSettings[nameof(RavenClient)]), new ContainerControlledLifetimeManager());
            Container.RegisterType<ILogExceptionService, LogExceptionService>(new ContainerControlledLifetimeManager());
            
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

       
        
    }
}
