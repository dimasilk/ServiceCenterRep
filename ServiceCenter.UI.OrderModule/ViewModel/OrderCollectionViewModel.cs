using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure.Constants;
using ServiceCenter.UI.Infrastructure.DialogService;
using ServiceCenter.UI.Infrastructure.ViewModel;
using ServiceCenter.UI.OrderModule.View;

namespace ServiceCenter.UI.OrderModule.ViewModel
{

    public class OrderCollectionViewModel : BaseNavigationAwareViewModel
    {
        private readonly IWcfOrderService _orderServiceClient;
        private readonly IDialogService _dialogService;
        private readonly IRegionManager _regionManager;
        private ObservableCollection<OrderItemViewModel> _ordersCollection;
        private OrderStatusDTO[] _statuses;
        private OrderFilterDTO _filter;

        //private bool _isBusy;

        public OrderCollectionViewModel(IWcfOrderService serviceClient, IEventAggregator eventAggregator, IDialogService dialogService, IRegionManager regionManager) : base(eventAggregator, regionManager)
        {
            OrdersCollection = new ObservableCollection<OrderItemViewModel>();
            _orderServiceClient = serviceClient;
            _dialogService = dialogService;
            _regionManager = regionManager;
            FilterChangedCommand = new DelegateCommand(FilterChanged);

            Filter = new OrderFilterDTO();
            GetOrders();
            GetStatuses();
           
           
        }

        public OrderStatusDTO[] Statuses
        {
            get { return _statuses; }
            set { SetProperty(ref _statuses, value); }
        }
        public OrderItemViewModel SelectedItem { get; set; }
        public ObservableCollection<OrderItemViewModel> OrdersCollection
        {
            get { return _ordersCollection; }
            set { SetProperty(ref _ordersCollection, value); }
        }

        public OrderFilterDTO Filter { get; set; }
        public ICommand FilterChangedCommand { get; set; }

        private async void GetOrders()
        {
            IsBusy = true;
           //async
            //var c = await _orderServiceClient.GetAllOrders();
            var b = await _orderServiceClient.GetOrdersByFilter(Filter);
            OrdersCollection = new ObservableCollection<OrderItemViewModel>(b.Select(x => new OrderItemViewModel(x)));

            IsBusy = false;
        }

        public void FilterChanged()
        {
            GetOrders();
        }

        private async void GetStatuses()
        {
            Statuses = await _orderServiceClient.GetOrderStatuses();
          
        }

        protected override void DeleteEntity(object parametr)
        {
            if (SelectedItem == null || IsBusy) return;

            var id = SelectedItem.Item.Id;
            _orderServiceClient.DeleteOrder(id);
            GetOrders();
        }

        protected override void AddEntity(object parametr)
        {
            if (IsBusy) return;
            OrderDTO result;
            var dialogResult = _dialogService.ShowDialog<AddEditOrderWindow, OrderDTO>("Add new order", out result);
            if (dialogResult.HasValue && dialogResult.Value && result != null)
            {
                _orderServiceClient.AddOrder(result);
                GetOrders();
            }
        }
    

        protected override void EditEntity(object parametr)
        {
            if (SelectedItem == null || IsBusy) return;
            OrderDTO result;
            var dialogResult = _dialogService.ShowDialog<AddEditOrderWindow, OrderDTO>("Edit order", out result, new ParameterOverride("item", SelectedItem.Item));
            if (dialogResult.HasValue && dialogResult.Value && result != null)
            {
                _orderServiceClient.UpdateOrder(result);
                GetOrders();
            }
        }

        protected override void InitModuleToolbar()
        {
            _regionManager.RequestNavigate(RegionNames.ModuleMenuRegion, nameof(OrderToolbarView));
        }
    }
}
