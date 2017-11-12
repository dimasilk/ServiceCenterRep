using System.ServiceModel;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
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
            _container.RegisterType<OrderToolbarViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IWcfOrderService, OrderServiceClient>(new ContainerControlledLifetimeManager());
            var rm = _container.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion(RegionNames.MainRegion, typeof (OrderView));
            rm.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(OrderToolbarView));

            //в тестовых целях, если оно пройдет значит данные успешно пришли с сервера))))
            //var data = _container.Resolve<IWcfOrderService>().GetAllOrders();
        }
    }
}
