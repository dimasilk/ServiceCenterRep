using System;
using System.ServiceModel;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;

namespace ServiceCenter.WcfService.WcfCompanies
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WcfCompanyService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы WcfCompanyService.svc или WcfCompanyService.svc.cs в обозревателе решений и начните отладку.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple, AutomaticSessionShutdown = true)]
    public class WcfCompanyService : IWcfCompanyService
    {
        private readonly ICompanyService _companyService;

        public WcfCompanyService(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        public async Task<CompanyDTO[]> GetAllCompanies()
        {
            var task = Task.Factory.StartNew(_companyService.GetAllCompanies);
            return await task.ConfigureAwait(false);
        }

        public async Task<CompanyDTO[]> GetCompaniesByFilter(CompanyFilterDTO filter)
        {
            var task = Task.Factory.StartNew(() => _companyService.GetCompaniesByFilter(filter));
            return await task.ConfigureAwait(false);
        }

        public void DeleteCompany(Guid companyId)
        {
            _companyService.DeleteCompany(companyId);
        }

        public void UpdateCompany(CompanyDTO company)
        {
            _companyService.UpdateCompany(company);
        }

        public Guid AddCompany(CompanyDTO company)
        {
            return _companyService.AddCompany(company);
        }

        public CompanyDTO GetCompanyById(Guid companyId)
        {
            return _companyService.GetCompanyById(companyId);
        }
    }
}
