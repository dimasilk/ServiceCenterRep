using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.UI.CompanyModule.View;
using ServiceCenter.UI.CompanyModule.ViewModel;
using ServiceCenter.UI.Infrastructure.Constants;

namespace ServiceCenter.UI.CompanyModule
{
    public class CompanyModule : IModule
    {
        private readonly IUnityContainer _container;
        public CompanyModule(IUnityContainer container)
        {
            _container = container;
        }
        public void Initialize()
        {
            _container.RegisterType<IWcfCompanyService, CompanyServiceClient>(new ContainerControlledLifetimeManager());
            _container.RegisterType<CompanyCollectionViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<object, CompanyCollectionView>(TabNames.CompaniesTab);
            _container.RegisterType<object, CompanyToolbarView>(nameof(CompanyToolbarView));
        }
    }
}
