using System;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using ServiceCenter.UI.Infrastructure.Constants;

namespace ServiceCenter.UI.NavigationModule.ViewModel
{
    public class NavigationBarViewModel
    {
        private readonly IRegionManager _regionManager;

        public NavigationBarViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            ItemSource =
                typeof (TabNames).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                    .Select(x => new NavigationItemViewModel {TabName = x.GetValue(null).ToString()})
                    .ToArray();
            NavigateCommand = new DelegateCommand<NavigationItemViewModel>(Navigate);
        }
        public NavigationItemViewModel[] ItemSource { get; set; }
        public ICommand NavigateCommand { get; set; }

        private void Navigate(NavigationItemViewModel itemViewModel)
        {
           if (itemViewModel == null || !itemViewModel.IsSelected) return;
           _regionManager.RequestNavigate(RegionNames.MainRegion, new Uri(itemViewModel.TabName, UriKind.Relative));
        }
    }
}
