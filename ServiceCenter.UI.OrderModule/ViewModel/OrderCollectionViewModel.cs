using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure.DialogService;
using ServiceCenter.UI.Infrastructure.ViewModel;
using ServiceCenter.UI.OrderModule.View;

namespace ServiceCenter.UI.OrderModule.ViewModel
{

    public class OrderCollectionViewModel : BaseNavigationAwareViewModel
    {
        private readonly IWcfOrderService _orderServiceClient;
        private readonly IDialogService _dialogService;
        private ObservableCollection<OrderItemViewModel> _ordersCollection;
       
        //private bool _isBusy;

        public OrderCollectionViewModel(IWcfOrderService serviceClient, IEventAggregator eventAggregator, IDialogService dialogService) : base(eventAggregator)
        {
            OrdersCollection = new ObservableCollection<OrderItemViewModel>();
            _orderServiceClient = serviceClient;
            _dialogService = dialogService;
            
            GetOrders();
           
        }

        public OrderItemViewModel SelectedItem { get; set; }
        public ObservableCollection<OrderItemViewModel> OrdersCollection
        {
            get { return _ordersCollection; }
            set { SetProperty(ref _ordersCollection, value); }
        }

        private async void GetOrders()
        {
            IsBusy = true;
           //async
            var c = await _orderServiceClient.GetAllOrders();
            OrdersCollection = new ObservableCollection<OrderItemViewModel>(c.Select(x => new OrderItemViewModel(x)));

            IsBusy = false;
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
    }
}
