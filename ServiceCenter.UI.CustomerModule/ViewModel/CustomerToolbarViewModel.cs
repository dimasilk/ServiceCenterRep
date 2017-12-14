using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using ServiceCenter.BL.Common;

namespace ServiceCenter.UI.CustomerModule.ViewModel
{
    public class CustomerToolbarViewModel : BindableBase
    {
        public CustomerToolbarViewModel (CustomerCollectionViewModel viewModel)
        {
            ViewModel = viewModel;
        }
        public CustomerCollectionViewModel ViewModel { get; private set; }
    }
}
