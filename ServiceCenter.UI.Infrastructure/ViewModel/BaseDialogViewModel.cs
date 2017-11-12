using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace ServiceCenter.UI.Infrastructure.ViewModel
{
    public abstract class BaseDialogViewModel : BaseViewModel
    {
        private object _dialogResultData;
        private bool? _dialogResult;
        public BaseDialogViewModel()
        { 
             OkCommand = new DelegateCommand<object>(OkClick);
             CancelCommand = new DelegateCommand(CancelClick);
        } 
        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        public bool? DialogResult
        {
            get { return _dialogResult; }
            set
            {
                SetProperty(ref _dialogResult, value);
            }
        }

        public object DialogResultData
        {
            get { return _dialogResultData; }
            set { SetProperty(ref _dialogResultData, value); }
        }
       

        public virtual void OkClick(object o)
        {
            DialogResult = true;
        }
        public void CancelClick()
        {
            DialogResult = false;
        }
        
    }
}
