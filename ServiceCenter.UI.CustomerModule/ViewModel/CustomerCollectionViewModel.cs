using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.CustomerModule.View;
using ServiceCenter.UI.Infrastructure.Constants;
using ServiceCenter.UI.Infrastructure.DialogService;
using ServiceCenter.UI.Infrastructure.ViewModel;

namespace ServiceCenter.UI.CustomerModule.ViewModel
{
    public class CustomerCollectionViewModel : BaseNavigationAwareViewModel
    {
        private readonly IWcfCustomerService _serviceClient;
        private readonly IDialogService _dialogService;
        private readonly IRegionManager _regionManager;
        private ObservableCollection<CustomerItemViewModel> _customersCollection;

        public CustomerCollectionViewModel(IWcfCustomerService serviceClient, IEventAggregator eventAggregator,
            IDialogService dialogService, IRegionManager regionManager) : base(eventAggregator, regionManager)
        {
            _serviceClient = serviceClient;
            _dialogService = dialogService;
            _regionManager = regionManager;
            FilterChangedCommand = new DelegateCommand(FilterChandeg);
            DoubleClickOnCustomerCommand = new DelegateCommand<CustomerItemViewModel>(DoubleClickOnCustomer);
            GetCustomers();
        }

        public CustomerItemViewModel SelectedItem { get; set; }
        public CustomerFilterDTO Filter { get; set; } = new CustomerFilterDTO();
        public ICommand FilterChangedCommand { get; set; }
        public ICommand DoubleClickOnCustomerCommand { get; set; }

        public ObservableCollection<CustomerItemViewModel> CustomerCollection
        {
            get { return _customersCollection; }
            set { SetProperty(ref _customersCollection, value); }
        }

        private async void GetCustomers()
        {
            IsBusy = true;
            //var c = await _serviceClient.GetAllCustomers();
            var c = await _serviceClient.GetCustomersByFilter(Filter);
            CustomerCollection =
                new ObservableCollection<CustomerItemViewModel>(c.Select(x => new CustomerItemViewModel(x)));
            IsBusy = false;
        }

        public void FilterChandeg()
        {
            GetCustomers();
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
            }
            GetCustomers();
        }
        protected override void InitModuleToolbar()
        {
            _regionManager.RequestNavigate(RegionNames.ModuleMenuRegion, nameof(CustomerToolbarView));
        }
        public void DoubleClickOnCustomer(CustomerItemViewModel itemViewModel)
        {

            SelectedItem = itemViewModel;
            EditEntity(SelectedItem);
        }
    }
}

  