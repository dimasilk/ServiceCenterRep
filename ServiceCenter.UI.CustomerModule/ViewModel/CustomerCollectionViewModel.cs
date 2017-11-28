using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.PubSubEvents;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.CustomerModule.View;
using ServiceCenter.UI.Infrastructure.DialogService;
using ServiceCenter.UI.Infrastructure.ViewModel;

namespace ServiceCenter.UI.CustomerModule.ViewModel
{
    public class CustomerCollectionViewModel : BaseNavigationAwareViewModel
    {
        private readonly IWcfCustomerService _serviceClient;
        private readonly IDialogService _dialogService;
        private ObservableCollection<CustomerItemViewModel> _customersCollection;

        public CustomerCollectionViewModel(IWcfCustomerService serviceClient, IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator)
        {
            _serviceClient = serviceClient;
            _dialogService = dialogService;

            GetCustomers();
        }

        public CustomerItemViewModel SelectedItem { get; set; }

        public ObservableCollection<CustomerItemViewModel> CustomerCollection
        {
            get { return _customersCollection; }
            set { SetProperty(ref _customersCollection, value); }
        }

        private async void GetCustomers()
        {
            var c = await _serviceClient.GetAllCustomers();
            CustomerCollection =
                new ObservableCollection<CustomerItemViewModel>(c.Select(x => new CustomerItemViewModel(x)));
        }


        protected override void DeleteEntity(object parametr)
        {
            if (SelectedItem == null) return;

            var id = SelectedItem.Item.Id;
            _serviceClient.DeleteCustomer(id);
            GetCustomers();
        }

        protected override void AddEntity(object parametr)
        {
            CustomerDTO result;
            var dialogResult = _dialogService.ShowDialog<CustomerView, CustomerDTO>("Add new customer", out result);
            if (dialogResult.HasValue && dialogResult.Value && result != null)
            {
                _serviceClient.AddCustomer(result);
                GetCustomers();
            }
        }


        protected override void EditEntity(object parametr)
        {
            if (SelectedItem == null) return;
            CustomerDTO result;
            var dialogResult = _dialogService.ShowDialog<CustomerView, CustomerDTO>("Edit order", out result,
                new ParameterOverride("item", SelectedItem.Item));
            if (dialogResult.HasValue && dialogResult.Value && result != null)
            {
                _serviceClient.UpdateCustomer(result);
                GetCustomers();
            }
        }
    }
}

  