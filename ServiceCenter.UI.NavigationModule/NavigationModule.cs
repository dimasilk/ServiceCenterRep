using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using ServiceCenter.UI.Infrastructure.Constants;
using ServiceCenter.UI.NavigationModule.View;
using ServiceCenter.UI.NavigationModule.ViewModel;

namespace ServiceCenter.UI.NavigationModule
{
    [Module(ModuleName = nameof(NavigationModule))]
    public class NavigationModule : IModule
    {
        private readonly IUnityContainer _container;
        public NavigationModule(IUnityContainer container)
        {
            _container = container;
        }
        public void Initialize()
        {
            _container.RegisterType<NavigationBarViewModel>(new ContainerControlledLifetimeManager());
            var rm = _container.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(NavigationBarView));
        }
    }
}
