using System.Reflection;
using Microsoft.Practices.Prism.Mvvm;
using ServiceCenter.UI.Infrastructure.Attributes;

namespace ServiceCenter.UI.NavigationModule.ViewModel
{
    public class NavigationItemViewModel : BindableBase
    {
        private bool _isSelected;

        public NavigationItemViewModel(FieldInfo fieldInfo)
        {
            TabName = fieldInfo.GetValue(null).ToString();
            ShowOnStartup = fieldInfo.GetCustomAttribute<ShowOnStartupAttribute>() != null;
            ModuleName = fieldInfo.GetCustomAttribute<ModuleInfoAttribute>()?.ModuleName;
        }
        public string TabName { get; set; }
        public bool ShowOnStartup { get; set; }
        public string ModuleName { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }
    }
}
