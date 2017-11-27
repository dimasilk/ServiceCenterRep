using System;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using ServiceCenter.UI.Infrastructure.Constants;
using ServiceCenter.UI.ToolbarModule.View;
using ServiceCenter.UI.ToolbarModule.ViewModel;

namespace ServiceCenter.UI.ToolbarModule
{
    public class ToolbarModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public ToolbarModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<OrderToolbarViewModel>(new ContainerControlledLifetimeManager());
            _regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(OrderToolbarView));
        }
    }
}
