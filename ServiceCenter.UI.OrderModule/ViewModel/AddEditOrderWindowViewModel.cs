using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.CompanyModule.View;
using ServiceCenter.UI.CustomerModule.View;
using ServiceCenter.UI.Infrastructure.DialogService;
using ServiceCenter.UI.Infrastructure.Interfaces;
using ServiceCenter.UI.Infrastructure.ViewModel;


namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class AddEditOrderWindowViewModel : BaseDialogViewModel
    {
        public ICommand DoubleClickOnPriceItemCommand { get; set; }
        public ICommand DoubleClickOnSelectedPriceItemCommand { get; set; }
        public ICommand EditCustomerCommand { get; set; }
        public ICommand EditCompanyCommand { get; set; }
        public ICommand PriceParameterChangedCommand { get; set; }


        public OrderDTO Item { get; set; }
        public bool IsOkButtonEnabled
        {
            get { return _isOkButtonEnabled; }
            set { SetProperty(ref _isOkButtonEnabled, value); }
        }

        public ObservableCollection<PricelistDTO> SelectedPricelistItems
        {
            get { return _selectedPricelistItems; }
            set { SetProperty(ref _selectedPricelistItems, value); }
        }
        public OrderStatusDTO[] Statuses
        {
            get { return _statuses; }
            set { SetProperty(ref _statuses, value); }
        }
        public PriceListTreeViewModel Prices
        {
            get { return _prices; }
            set { SetProperty(ref _prices, value); }
        }
        public double OrderSum {
            get { return _orderSum; }
            set { SetProperty(ref _orderSum, value); }
        }
        public double Coeff
        {
            get { return _coeff; }
            set { SetProperty(ref _coeff, value); }
        }
        public double OrderAmount
        {
            get { return _orderAmount; }
            set { SetProperty(ref _orderAmount, value); }
        }
        public AddEditOrderWindowViewModel(OrderDTO item, IWcfOrderService serviceClient, IUserIdService userIdService, IEventAggregator eventAggregator, IDialogService dialogService, IWcfCustomerService customerService, IWcfCompanyService companyService)
        {
            Item = item ?? new OrderDTO();

            if (Item.PricelistItems.Count != 0) CountOrderSum();
            if (Item.PriceCoefficient != null)
                Coeff = (double)Item.PriceCoefficient;
            else
                Coeff = 1;
            if (Item.OrderAmount != null) OrderAmount = (double)Item.OrderAmount;

            _serviceClient = serviceClient;
            _userIdService = userIdService;
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
            _customerService = customerService;
            _companyService = companyService;
            DoubleClickOnPriceItemCommand = new DelegateCommand<PriceListViewModel>(DoubleClickOnPriceItem);
            DoubleClickOnSelectedPriceItemCommand = new DelegateCommand<PricelistDTO>(DoubleClickOnSelectedPriceItem);
            EditCustomerCommand = new DelegateCommand<CustomerDTO>(EditCustomer);
            EditCompanyCommand = new DelegateCommand<CompanyDTO>(EditCompany);
            PriceParameterChangedCommand = new DelegateCommand(PriceParameterChanged);

            _selectedPricelistItems = new ObservableCollection<PricelistDTO>();
            GetPrices();
            GetStatuses();
        }

        private readonly IWcfOrderService _serviceClient;
        private readonly IUserIdService _userIdService;
        private readonly IEventAggregator _eventAggregator;
        private readonly IDialogService _dialogService;
        private readonly IWcfCustomerService _customerService;
        private readonly IWcfCompanyService _companyService;
        private ObservableCollection<PricelistDTO> _selectedPricelistItems;
        private OrderStatusDTO[] _statuses;
        private PriceListTreeViewModel _prices;
        private double _coeff;
        private double _orderSum;
        private double _orderAmount;
        private bool _isOkButtonEnabled = true;


        public override void OkClick(object o)
        {
            if (Item.Customer == null && Item.Company == null)
            {
                IsOkButtonEnabled = false;
                return;
            }
            
            DialogResultData = Item;
            if (Item.IdUserCreated == Guid.Empty) Item.IdUserCreated = _userIdService.GetCreatorId();
            base.OkClick(o);
        }
        private async void GetStatuses()
        {
            Statuses = await _serviceClient.GetOrderStatuses();
            if (Item.Status == null) return;
            Item.Status = Statuses.FirstOrDefault(x => x.Id == Item.Status.Id);
            Item.OnPropertyChanged(nameof(Item.Status));
        }

        private async void GetPrices()
        {
            Prices = new PriceListTreeViewModel(await _serviceClient.GetFullPriceList());
            SelectedPricelistItems =
                new ObservableCollection<PricelistDTO>(_serviceClient.GetPriceListItemsByOrderId(Item.Id));
        }

        public void DoubleClickOnPriceItem(PriceListViewModel priceListViewModel)
        {
            if (_selectedPricelistItems.Select(x => x.Id).Contains(priceListViewModel.PricelistDto.Id)) return;
            _selectedPricelistItems.Add(priceListViewModel.PricelistDto);
            Item.PricelistItems = _selectedPricelistItems.ToArray();
            if (priceListViewModel.PricelistDto.Price != null)
                OrderSum += (double) priceListViewModel.PricelistDto.Price;
            CountOrderAmount();
        }
        public void DoubleClickOnSelectedPriceItem(PricelistDTO pricelistDto)
        {
            _selectedPricelistItems.Remove(pricelistDto);
            Item.PricelistItems = _selectedPricelistItems.ToArray();
            if (pricelistDto.Price != null) OrderSum -= (double) pricelistDto.Price;
            CountOrderAmount();
        }

        public void EditCustomer(CustomerDTO customerDto)
        {
            CustomerDTO result;
            var dialogResult = Item.Customer == null ? _dialogService.ShowDialog<CustomerView, CustomerDTO>("Edit Customer", out result) : _dialogService.ShowDialog<CustomerView, CustomerDTO>("Edit Customer", out result, new ParameterOverride("item", Item.Customer));
            if (!dialogResult.HasValue || !dialogResult.Value || result == null) return;
            if (Item.Customer != null)
                _customerService.UpdateCustomer(result);
            else
            {
                var id = _customerService.AddCustomer(result);
                Item.Customer = _customerService.GetCustomerById(id);
                Item.OnPropertyChanged(nameof(Item.Customer));
            }
            IsOkButtonEnabled = true;

        }

        public void EditCompany(CompanyDTO companyDto)
        {
            CompanyDTO result;
            var dialogResult = Item.Company == null ? _dialogService.ShowDialog<CompanyView, CompanyDTO>("Edit Company", out result) : _dialogService.ShowDialog<CompanyView, CompanyDTO>("Edit Company", out result, new ParameterOverride("item", Item.Company));
            if (!dialogResult.HasValue || !dialogResult.Value || result == null) return;
            if (Item.Company != null)
                _companyService.UpdateCompany(result);
            else
            {
                var id = _companyService.AddCompany(result);
                Item.Company = _companyService.GetCompanyById(id);
                Item.OnPropertyChanged(nameof(Item.Company));
            }
            IsOkButtonEnabled = true;
        }

        public void PriceParameterChanged()
        {
            CountOrderAmount();
        }

        private void CountOrderAmount()
        {
            OrderAmount = OrderSum * Coeff;
            Item.OrderAmount = OrderAmount;
            Item.PriceCoefficient = Coeff;
        }

        private void CountOrderSum()
        {
            double x = 0;
            foreach (var element in Item.PricelistItems)
            {
                if (element.Price != null) x += (double) element.Price;
            }
            OrderSum = x;
        }
        
    }
}
