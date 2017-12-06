using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure.ViewModel;

namespace ServiceCenter.UI.CompanyModule.ViewModel
{
    public class AddEditCompanyWindowViewModel : BaseDialogViewModel
    {
        private readonly IWcfCompanyService _companyService;
        private ObservableCollection<CompanyItemViewModel> _companyFilteredCollection;

        public AddEditCompanyWindowViewModel(CompanyDTO item, IWcfCompanyService companyService)
        {
            _companyService = companyService;
            Item = item ?? new CompanyDTO();
            SearchCompanyCommand = new DelegateCommand(Search);
            DoubleClickOnCompanyCommand = new DelegateCommand<CompanyItemViewModel>(DoubleClickOnCompany);
        }
        public CompanyDTO Item { get; set; }
        public ICommand SearchCompanyCommand { get; set; }
        public ICommand DoubleClickOnCompanyCommand { get; set; }
        public ObservableCollection<CompanyItemViewModel> CompanyFilteredCollection
        {
            get { return _companyFilteredCollection; }
            set { SetProperty(ref _companyFilteredCollection, value); }
        }

        public override void OkClick(object o)
        {
            DialogResultData = Item;
            // if (Item.IdUserCreated == Guid.Empty) Item.IdUserCreated = _userIdService.GetCreatorId();
            base.OkClick(o);
        }
        public async void Search()
        {
            if (Item.Id != Guid.Empty) return;
            CompanyFilterDTO filter = new CompanyFilterDTO { Name = Item.Name, Info = Item.Info, Phone = Item.Phone, Adress = Item.Adress};
            var c = await _companyService.GetCompaniesByFilter(filter);
            CompanyFilteredCollection =
                new ObservableCollection<CompanyItemViewModel>(c.Select(x => new CompanyItemViewModel(x)));
        }

        public void DoubleClickOnCompany(CompanyItemViewModel itemViewModel)
        {
            Item = itemViewModel.Item;
            OkClick(Item);
        }
    }
}
