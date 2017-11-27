using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.UI.Infrastructure.Constants;
using ServiceCenter.UI.OrderModule.View;

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
           // _container.RegisterType<OrderCollectionViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IWcfOrderService, OrderServiceClient>(new ContainerControlledLifetimeManager());
            _container.RegisterType<object, OrderView>(TabNames.OrdersTab);
        }
    }
}
