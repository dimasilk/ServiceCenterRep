using System;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using ServiceCenter.UI.Infrastructure.Constants;

namespace ServiceCenter.UI.NavigationModule.ViewModel
{
    public class NavigationBarViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly IModuleManager _moduleManager;

        public NavigationBarViewModel(IRegionManager regionManager, IModuleManager moduleManager)
        {
            _regionManager = regionManager;
            _moduleManager = moduleManager;
            ItemSource =
                typeof (TabNames).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                    .Select(x => new NavigationItemViewModel(x) )
                    .ToArray();
            NavigateCommand = new DelegateCommand<NavigationItemViewModel>(Navigate);
            NavigateOnStartup();
        }
        public NavigationItemViewModel[] ItemSource { get; set; }
        public ICommand NavigateCommand { get; set; }

        private void Navigate(NavigationItemViewModel itemViewModel)
        {
           if (itemViewModel == null || !itemViewModel.IsSelected) return;
            EventHandler<LoadModuleCompletedEventArgs> handler = null;
            var navigateAction = new Action(() => _regionManager.RequestNavigate(RegionNames.MainRegion, new Uri(itemViewModel.TabName, UriKind.Relative)));
            navigateAction.Invoke();
            handler = (sender, args) =>
            {
                ((IModuleManager) sender).LoadModuleCompleted -= handler;
                navigateAction.Invoke();
            };
            _moduleManager.LoadModuleCompleted += handler;
            _moduleManager.LoadModule(itemViewModel.ModuleName);
        }

        private void NavigateOnStartup()
        {
            var item = ItemSource.FirstOrDefault(x => x.ShowOnStartup);
            if (item == null) return;
            item.IsSelected = true;
            Navigate(item);
        }

        
    }
}
