using System.ServiceModel;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
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
            _container.RegisterInstance(new ChannelFactory<IWcfOrderService>(nameof(IWcfOrderService)));
            //_container.RegisterInstance(new ChannelFactory<IWcfOrderService>("WSHTTP_IWcfOrderService"));
            _container.RegisterType<IWcfOrderService, OrderServiceClient>();
            var rm = _container.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion(RegionNames.MainRegion, typeof (OrderView));
            //это в тестовых целях, если оно пройдет значит данные успешно пришли с сервера))))
           var data = _container.Resolve<IWcfOrderService>().GetAllOrders();
        }
    }
}
