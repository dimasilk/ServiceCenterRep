using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure.ViewModel;

namespace ServiceCenter.UI.CustomerModule.ViewModel
{
    public class AddEditCustomerWindowViewModel : BaseDialogViewModel
    {
        private readonly IWcfCustomerService _customerService;
        private ObservableCollection<CustomerItemViewModel> _customersFilteredCollection;

        public AddEditCustomerWindowViewModel(CustomerDTO item, IWcfCustomerService customerService)
        {
            _customerService = customerService;
            Item = item ?? new CustomerDTO();
            SearchCustomerCommand = new DelegateCommand(Search);
            DoubleClickOnCustomerCommand = new DelegateCommand<CustomerItemViewModel>(DoubleClickOnCustomer);
        }
        public CustomerDTO Item { get; set; }

        public ObservableCollection<CustomerItemViewModel> CustomerFilteredCollection
        {
            get { return _customersFilteredCollection; }
            set { SetProperty(ref _customersFilteredCollection, value); }
        }
        public ICommand SearchCustomerCommand { get; set; }
        public ICommand DoubleClickOnCustomerCommand { get; set; }


        public override void OkClick(object o)
        {
            DialogResultData = Item;
           // if (Item.IdUserCreated == Guid.Empty) Item.IdUserCreated = _userIdService.GetCreatorId();
            base.OkClick(o);
        }

        public async void Search()
        {
            if (Item.Id != Guid.Empty) return;
            CustomerFilterDTO filter = new CustomerFilterDTO {FullName = Item.FullName, Info = Item.Info, Phone = Item.Phone};
            var c = await _customerService.GetCustomersByFilter(filter);
            CustomerFilteredCollection =
                new ObservableCollection<CustomerItemViewModel>(c.Select(x => new CustomerItemViewModel(x)));
        }

        public void DoubleClickOnCustomer(CustomerItemViewModel itemViewModel)
        {
            Item = itemViewModel.Item;
            OkClick(Item);
        }
    }
}
