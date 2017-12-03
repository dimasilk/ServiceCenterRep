using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.UI.CompanyModule;
using ServiceCenter.UI.CustomerModule;
using ServiceCenter.UI.Infrastructure.Constants;
using ServiceCenter.UI.OrderModule.View;
using ServiceCenter.UI.OrderModule.ViewModel;

namespace ServiceCenter.UI.OrderModule
{
    [Module(ModuleName = nameof(OrderModule))]
    public class OrderModule : IModule
    {
        private readonly IUnityContainer _container;
        public OrderModule(IUnityContainer container)
        {
            _container = container;
        }
        public void Initialize()
        {
            _container.RegisterType<OrderCollectionViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IWcfOrderService, OrderServiceClient>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IWcfCustomerService, CustomerServiceClient>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IWcfCompanyService, CompanyServiceClient>(new ContainerControlledLifetimeManager());
            _container.RegisterType<object, OrderView>(TabNames.OrdersTab);
            _container.RegisterType<object, OrderToolbarView>(nameof(OrderToolbarView));
        }
    }
}
