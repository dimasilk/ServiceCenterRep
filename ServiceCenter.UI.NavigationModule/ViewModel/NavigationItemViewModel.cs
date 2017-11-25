using Microsoft.Practices.Prism.Mvvm;

namespace ServiceCenter.UI.NavigationModule.ViewModel
{
    public class NavigationItemViewModel : BindableBase
    {
        private bool _isSelected;
        public string TabName { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }
    }
}
