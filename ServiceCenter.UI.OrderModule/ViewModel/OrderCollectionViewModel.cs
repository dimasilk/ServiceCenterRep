using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Prism.Mvvm;

namespace ServiceCenter.UI.OrderModule.ViewModel
{

    public class OrderCollectionViewModel : BindableBase
    {
        public OrderCollectionViewModel(OrderServiceClient serviceClient)
        {
            OrdersCollection = new ObservableCollection<OrderItemViewModel>();
            _orderServiceClient = serviceClient;
            GetOrders();
        }

        private readonly OrderServiceClient _orderServiceClient;
        public ObservableCollection<OrderItemViewModel> OrdersCollection { get; set; }

        private void GetOrders()
        {
            OrdersCollection = new ObservableCollection<OrderItemViewModel>(_orderServiceClient.GetAllOrders().Select(x => new OrderItemViewModel(x)));

        }

    }
}
