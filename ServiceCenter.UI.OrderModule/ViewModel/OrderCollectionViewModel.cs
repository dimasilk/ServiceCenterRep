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
        public OrderCollectionViewModel(OrderServiceClient serviceClient, IEventAggregator eventAggregator)
        {
            OrdersCollection = new ObservableCollection<OrderItemViewModel>();
            _orderServiceClient = serviceClient;
            eventAggregator.GetEvent<DeleteOrderEvent>().Subscribe(DeleteOrder);
            GetOrders();
           
        }
        public IDialogService DialogService { get; set; } = new DialogService();
        private readonly OrderServiceClient _orderServiceClient;
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
            var dialogResult = DialogService.ShowDialog<AddOrderWindow>("qwer", out result);
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
