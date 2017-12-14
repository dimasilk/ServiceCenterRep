using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using ServiceCenter.BL.Common;

namespace ServiceCenter.UI.CompanyModule.ViewModel
{
    public class CompanyToolbarViewModel : BindableBase
    {
        public CompanyToolbarViewModel(CompanyCollectionViewModel viewModel)
        {
            ViewModel = viewModel;
        }
        public CompanyCollectionViewModel ViewModel { get; private set; }
    }
}
