using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using ServiceCenter.BL.Common;
using ServiceCenter.UI.Infrastructure.DialogService;
using ServiceCenter.UI.Infrastructure.ViewModel;

namespace ServiceCenter.UI.CustomerModule.ViewModel
{
    public class CustomerCollectionViewModel : BaseNavigationAwareViewModel
    {
        private readonly IWcfCustomerService _serviceClient;
        private readonly IDialogService _dialogService;
        private ObservableCollection<CustomerItemViewModel> _customersCollection;

        public CustomerCollectionViewModel(IWcfCustomerService serviceClient, IEventAggregator eventAggregator, IDialogService dialogService) : base (eventAggregator)
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
            CustomerCollection = new ObservableCollection<CustomerItemViewModel>(c.Select(x => new CustomerItemViewModel(x)));
        }
    }
}
