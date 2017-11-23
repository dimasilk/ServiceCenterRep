using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.UI.Infrastructure.Constants;
using ServiceCenter.UI.OrderModule.View;

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
            //rm.RegisterViewWithRegion(RegionNames.MainRegion, typeof(OrderView));
            rm.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(OrderToolbarView));
        }
    }
}
