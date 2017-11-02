using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            OrdersCollection.Clear();
            var o = _orderServiceClient.GetAllOrders();
            foreach (var element in o)
            {
                OrdersCollection.Add(new OrderItemViewModel(element));
            }

        }

    }
}
