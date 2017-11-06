using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class AddOrderWindowViewModel : BindableBase
    {
        public AddOrderWindowViewModel()
        {
            OkCommand = new DelegateCommand(OkClick);
            CancelCommand = new DelegateCommand(CancelClick);
        }
        public OrderDTO Item { get; set; } = new OrderDTO();
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

        private bool? _dialogResult;

        public void OkClick()
        {
            DialogResult = true;
        }
        public void CancelClick()
        {
            DialogResult = false;
        }
    }
}
