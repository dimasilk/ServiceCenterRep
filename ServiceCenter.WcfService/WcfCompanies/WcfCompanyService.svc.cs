using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;

namespace ServiceCenter.WcfService.WcfCompanies
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WcfCompanyService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы WcfCompanyService.svc или WcfCompanyService.svc.cs в обозревателе решений и начните отладку.
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

        public void DeleteCompany(Guid companyId)
        {
            _companyService.DeleteCompany(companyId);
        }

        public void UpdateCustomer(CompanyDTO company)
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
