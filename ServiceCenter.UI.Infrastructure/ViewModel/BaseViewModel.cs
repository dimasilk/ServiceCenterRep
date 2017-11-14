using Microsoft.Practices.Prism.Mvvm;

namespace ServiceCenter.UI.Infrastructure.ViewModel
{
    public abstract class BaseViewModel : BindableBase
    {
        public bool IsBusy
        {
            get { return _isBusy; } 
            set { SetProperty(ref _isBusy, value); }
        }

        private bool _isBusy;
    }
}
