using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using ServiceCenter.BL.Common;
using ServiceCenter.UI.CompanyModule.View;
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
            _container.RegisterType<object, CompanyCollectionView>(TabNames.CompaniesTab);
        }
    }
}
