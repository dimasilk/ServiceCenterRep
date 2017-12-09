using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.UI.CustomerModule.ViewModel
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
