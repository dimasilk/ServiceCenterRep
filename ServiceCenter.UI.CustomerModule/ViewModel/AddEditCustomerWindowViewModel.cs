using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
        public CustomerDTO Item { get; set; }

        public ObservableCollection<CustomerItemViewModel> CustomerFilteredCollection
        {
            get { return _customersFilteredCollection; }
            set { SetProperty(ref _customersFilteredCollection, value); }
        }
        public ICommand SearchCustomerCommand { get; set; }


        public override void OkClick(object o)
        {
            DialogResultData = Item;
           // if (Item.IdUserCreated == Guid.Empty) Item.IdUserCreated = _userIdService.GetCreatorId();
            base.OkClick(o);
        }

        public void Search()
        {
            var c = _customerService.GetAllCustomers().Result;
            CustomerFilteredCollection =
                new ObservableCollection<CustomerItemViewModel>(c.Select(x => new CustomerItemViewModel(x)));
        }
    }
}
