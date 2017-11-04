using Microsoft.Practices.Prism.Mvvm;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class OrderItemViewModel : BindableBase
    {
        public OrderItemViewModel(OrderDTO orderDto)
        {
            Item = orderDto;
        }
       public OrderDTO Item { get; set; }
    }
}
