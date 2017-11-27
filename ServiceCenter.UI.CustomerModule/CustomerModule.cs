using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.UI.CustomerModule.View;
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
            _container.RegisterType<object, CustomerCollectionView>(TabNames.CustomersTab);
        }
    }
}
