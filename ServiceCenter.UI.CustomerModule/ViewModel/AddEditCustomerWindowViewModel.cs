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
        private readonly IWcfOrderService _orderService;
        private ObservableCollection<CustomerItemViewModel> _customersFilteredCollection;
        private ObservableCollection<OrderItemViewModel> _ordersFilteredCollection;

        public AddEditCustomerWindowViewModel(CustomerDTO item, IWcfCustomerService customerService, IWcfOrderService orderService)
        {
            _customerService = customerService;
            _orderService = orderService;
            Item = item ?? new CustomerDTO();
            SearchCustomerCommand = new DelegateCommand(Search);
            DoubleClickOnCustomerCommand = new DelegateCommand<CustomerItemViewModel>(DoubleClickOnCustomer);
            GetOrdersByCustomer();
        }
        public CustomerDTO Item { get; set; }
        public ObservableCollection<OrderItemViewModel> OrdersFilteredCollection
        {
            get { return _ordersFilteredCollection; }
            set { SetProperty(ref _ordersFilteredCollection, value); }
        }

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

        public async void  GetOrdersByCustomer()
        {
            if (Item.Id == Guid.Empty) return;
            var filter = new OrderFilterDTO {Customer = Item};
            var c = await _orderService.GetOrdersByFilter(filter);
            OrdersFilteredCollection = new ObservableCollection<OrderItemViewModel>(c.Select(x => new OrderItemViewModel(x)));
        }

        public async void Search()
        {
            if (Item.Id != Guid.Empty) return;
            var filter = new CustomerFilterDTO {FullName = Item.FullName, Info = Item.Info, Phone = Item.Phone};
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
