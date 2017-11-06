using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using ServiceCenter.UI.Infrastructure.DialogService;
using ServiceCenter.UI.OrderModule.AggregatedEvent;
using ServiceCenter.UI.OrderModule.View;

namespace ServiceCenter.UI.OrderModule.ViewModel
{

    public class OrderCollectionViewModel : BindableBase
    {
        private readonly OrderServiceClient _orderServiceClient;
        private readonly IDialogService _dialogService;
        public OrderCollectionViewModel(OrderServiceClient serviceClient, IEventAggregator eventAggregator, IDialogService dialogService)
        {
            OrdersCollection = new ObservableCollection<OrderItemViewModel>();
            _orderServiceClient = serviceClient;
            _dialogService = dialogService;
            eventAggregator.GetEvent<DeleteOrderEvent>().Subscribe(DeleteOrder);
            eventAggregator.GetEvent<AddOrderEvent>().Subscribe(AddOrder);
            eventAggregator.GetEvent<EditOrderEvent>().Subscribe(EditOrder);
            GetOrders();
           
        }
        
        public ObservableCollection<OrderItemViewModel> OrdersCollection { get; set; }

        private void GetOrders()
        {
            OrdersCollection = new ObservableCollection<OrderItemViewModel>(_orderServiceClient.GetAllOrders().Select(x => new OrderItemViewModel(x)));
        }

        public OrderItemViewModel SelectedItem { get; set; }

        private void DeleteOrder(object parametr)
        {
            if (SelectedItem == null) return;
            
            OrdersCollection.Remove(SelectedItem);
            _orderServiceClient.DeleteOrder(SelectedItem.Item.Id);
        }

        private void AddOrder(object parametr)
        {
            object result;
            var dialogResult = _dialogService.ShowDialog<AddOrderWindow>("Add new order", out result);
            if (dialogResult.HasValue && dialogResult.Value)
            {
                var order = result as OrderItemViewModel;
                if (order != null) OrdersCollection.Add(order);
            }
        }

        private void EditOrder(object parametr)
        {
            
        }

    }
}
