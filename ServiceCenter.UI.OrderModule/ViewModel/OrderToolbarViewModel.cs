using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class OrderToolbarViewModel
    {
        public OrderCollectionViewModel ViewModel { get; private set; }

        public OrderToolbarViewModel (OrderCollectionViewModel orderCollectionViewModel)
        {
            ViewModel = orderCollectionViewModel;
        }
    }
}
