using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure.Constants;
using ServiceCenter.UI.Infrastructure.DialogService;
using ServiceCenter.UI.Infrastructure.Interfaces;
using ServiceCenter.UI.OrderModule.AggregatedEvent;
using ServiceCenter.UI.OrderModule.View;

namespace ServiceCenter.UI.OrderModule.ViewModel
{

    public class OrderCollectionViewModel : BindableBase
    {
        private readonly IWcfOrderService _orderServiceClient;
        private readonly IDialogService _dialogService;
        private ObservableCollection<OrderItemViewModel> _ordersCollection;
       
        //private bool _isBusy;

        public OrderCollectionViewModel(IWcfOrderService serviceClient, IEventAggregator eventAggregator, IDialogService dialogService)
        {
            OrdersCollection = new ObservableCollection<OrderItemViewModel>();
            _orderServiceClient = serviceClient;
            _dialogService = dialogService;
            eventAggregator.GetEvent<DeleteOrderEvent>().Subscribe(DeleteOrder);
            eventAggregator.GetEvent<AddOrderEvent>().Subscribe(AddOrder);
            eventAggregator.GetEvent<EditOrderEvent>().Subscribe(EditOrder);
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
            //_isBusy = true;
           //async
            var c = await _orderServiceClient.GetAllOrders();
            OrdersCollection = new ObservableCollection<OrderItemViewModel>(c.Select(x => new OrderItemViewModel(x)));

            //sync
            //OrdersCollection = new ObservableCollection<OrderItemViewModel>(_orderServiceClient.GetAllOrders().Result.Select(x => new OrderItemViewModel(x)));
           // _isBusy = false;
        }

       

        private void DeleteOrder(object parametr)
        {
            if (SelectedItem == null) return;

            var id = SelectedItem.Item.Id;
            _orderServiceClient.DeleteOrder(id);
            GetOrders();
        }

        private void AddOrder(object parametr)
        {
            OrderDTO result;
            var dialogResult = _dialogService.ShowDialog<AddEditOrderWindow, OrderDTO>("Add new order", out result);
            if (dialogResult.HasValue && dialogResult.Value && result != null)
            {
                _orderServiceClient.AddOrder(result);
                GetOrders();
            }
        }
    

        private void EditOrder(object parametr)
        {
            if (SelectedItem == null) return;
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
