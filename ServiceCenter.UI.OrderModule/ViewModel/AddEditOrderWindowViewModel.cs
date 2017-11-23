using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure.Interfaces;
using ServiceCenter.UI.Infrastructure.ViewModel;


namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class AddEditOrderWindowViewModel : BaseDialogViewModel
    {
        public ICommand DoubleClickOnPriceItemCommand { get; set; }
        public ICommand DoubleClickOnSelectedPriceItemCommand { get; set; }

        public OrderDTO Item { get; set; }

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
        public AddEditOrderWindowViewModel(OrderDTO item, IWcfOrderService serviceClient, IUserIdService userIdService)
        {
            Item = item ?? new OrderDTO();
            _serviceClient = serviceClient;
            _userIdService = userIdService;
            DoubleClickOnPriceItemCommand = new DelegateCommand<PriceListViewModel>(DoubleClickOnPriceItem);
            DoubleClickOnSelectedPriceItemCommand = new DelegateCommand<PricelistDTO>(DoubleClickOnSelectedPriceItem);

            _selectedPricelistItems = new ObservableCollection<PricelistDTO>();
            GetPrices();
            GetStatuses();
        }

        private readonly IWcfOrderService _serviceClient;
        private readonly IUserIdService _userIdService;
        private ObservableCollection<PricelistDTO> _selectedPricelistItems;
        private OrderStatusDTO[] _statuses;
        private PriceListTreeViewModel _prices;
        


        public override void OkClick(object o)
        {
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
        }
        public void DoubleClickOnSelectedPriceItem(PricelistDTO pricelistDto)
        {
            _selectedPricelistItems.Remove(pricelistDto);
            Item.PricelistItems = _selectedPricelistItems.ToArray();
        }
    }
}
