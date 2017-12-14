using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.CompanyModule.View;
using ServiceCenter.UI.Infrastructure.Constants;
using ServiceCenter.UI.Infrastructure.DialogService;
using ServiceCenter.UI.Infrastructure.ViewModel;

namespace ServiceCenter.UI.CompanyModule.ViewModel
{
    public class CompanyCollectionViewModel : BaseNavigationAwareViewModel
    {
        private readonly IWcfCompanyService _serviceClient;
        private readonly IDialogService _dialogService;
        private readonly IRegionManager _regionManager;
        private ObservableCollection<CompanyItemViewModel> _customersCollection;

        public CompanyCollectionViewModel(IWcfCompanyService serviceClient, IEventAggregator eventAggregator,
        IDialogService dialogService, IRegionManager regionManager) : base(eventAggregator, regionManager)
        {
            _serviceClient = serviceClient;
            _dialogService = dialogService;
            _regionManager = regionManager;
            FilterChangedCommand = new DelegateCommand(FilterChanged);

            GetCompanies();
        }

        public CompanyItemViewModel SelectedItem { get; set; }
        public CompanyFilterDTO Filter { get; set; } = new CompanyFilterDTO();
        public ICommand FilterChangedCommand { get; set; }

        public ObservableCollection<CompanyItemViewModel> CompanyCollection
        {
            get { return _customersCollection; }
            set { SetProperty(ref _customersCollection, value); }
        }

        private async void GetCompanies()
        {
            IsBusy = true;
            // var c = await _serviceClient.GetAllCompanies();
            var c = await _serviceClient.GetCompaniesByFilter(Filter);
            CompanyCollection =
            new ObservableCollection<CompanyItemViewModel>(c.Select(x => new CompanyItemViewModel(x)));
            IsBusy = false;
        }


        protected override void DeleteEntity(object parametr)
        {
            if (SelectedItem == null) return;

            var id = SelectedItem.Item.Id;
            _serviceClient.DeleteCompany(id);
            GetCompanies();
        }

        protected override void AddEntity(object parametr)
        {
            CompanyDTO result;
            var dialogResult = _dialogService.ShowDialog<CompanyView, CompanyDTO>("Add new company", out result);
            if (dialogResult.HasValue && dialogResult.Value && result != null)
            {
                _serviceClient.AddCompany(result);
                GetCompanies();
            }
        }


        protected override void EditEntity(object parametr)
        {
            if (SelectedItem == null) return;
            CompanyDTO result;
            var dialogResult = _dialogService.ShowDialog<CompanyView, CompanyDTO>("Edit company", out result,
            new ParameterOverride("item", SelectedItem.Item));
            if (dialogResult.HasValue && dialogResult.Value && result != null)
            {
                _serviceClient.UpdateCompany(result);
            }
            GetCompanies();
        }

        private void FilterChanged()
        {
            GetCompanies();
        }
        protected override void InitModuleToolbar()
        {
            _regionManager.RequestNavigate(RegionNames.ModuleMenuRegion, nameof(CompanyToolbarView));
        }

    }
}
