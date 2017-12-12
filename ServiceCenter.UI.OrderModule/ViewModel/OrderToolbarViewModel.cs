using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.CustomerModule.ViewModel;

namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class OrderToolbarViewModel : BindableBase
    {
        private readonly IWcfCustomerService _customerService;
        private readonly IWcfCompanyService _companyService;
        private ObservableCollection<CustomerDTO> _customersFilteredCollection;
        private ObservableCollection<CompanyDTO> _companiesFilteredCollection;


        public OrderToolbarViewModel (OrderCollectionViewModel orderCollectionViewModel, IWcfCustomerService customerService, IWcfCompanyService companyService)
        {
            _customerService = customerService;
            _companyService = companyService;
            ViewModel = orderCollectionViewModel;
            SearchCustomerCommand = new DelegateCommand(SearchCustomer);
            GetCustomers();
            GetCompanies();
        }
        public OrderCollectionViewModel ViewModel { get; private set; }
        public ICommand SearchCustomerCommand { get; set; }
        public CustomerDTO SelectedCustomer { get; set; } = new CustomerDTO();
        public CustomerFilterDTO Filter { get; set; } = new CustomerFilterDTO();

        public string FullName
        {
            get { return Filter.FullName; }
            set
            {
                Filter.FullName = value;
                OnPropertyChanged(() => FullName);
                SearchCustomer();
            }
        }
        public ObservableCollection<CustomerDTO> CustomerFilteredCollection
        {
            get { return _customersFilteredCollection; }
            set { SetProperty(ref _customersFilteredCollection, value); }
        }
        public ObservableCollection<CompanyDTO> CompanyFilteredCollection
        {
            get { return _companiesFilteredCollection; }
            set { SetProperty(ref _companiesFilteredCollection, value); }
        }

        public async void SearchCustomer()
        {
            //var res = await _customerService.GetCustomersByFilter(Filter);
           // CustomerFilteredCollection =
             //   new ObservableCollection<CustomerDTO>(res.Select(x => x));

        }

        public async void GetCustomers()
        {
            var res = await _customerService.GetAllCustomers();
            CustomerFilteredCollection =
                new ObservableCollection<CustomerDTO>(res.Select(x => x));
        }
        public async void GetCompanies()
        {
            var res = await _companyService.GetAllCompanies();
            CompanyFilteredCollection =
                new ObservableCollection<CompanyDTO>(res.Select(x => x));
        }
       
    }
}
