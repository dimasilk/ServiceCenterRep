using System;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.UI.Infrastructure.Constants;

namespace ServiceCenter.UI.CustomerModule
{
    [Module(ModuleName = nameof(CustomerModule))]
    public class CustomerModule : IModule
    {
        private readonly IUnityContainer _container;
        public CustomerModule(IUnityContainer container)
        {
            _container = container;
        }
        public void Initialize()
        {
            _container.RegisterType<IWcfCustomerService, CustomerServiceClient>(new ContainerControlledLifetimeManager());
            var rm = _container.Resolve<IRegionManager>();

            //var q = _container.Resolve<IWcfCustomerService>();
            //var a = q.GetCustomerById(new Guid("71F93D6B-73D0-E711-9BD6-1C1B0DF74675"));

        }
    }
}
