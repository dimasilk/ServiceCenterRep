using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure;
using ServiceCenter.UI.Infrastructure.Interfaces;

namespace ServiceCenter.UI.CompanyModule
{
    public class CompanyServiceClient : WcfClientBase<IWcfCompanyService>, IWcfCompanyService
    {
        public Task<CompanyDTO[]> GetAllCompanies()
        {
            return Channel.GetAllCompanies();
        }

        public void DeleteCompany(Guid companyId)
        {
            Channel.DeleteCompany(companyId);
        }

        public void UpdateCustomer(CompanyDTO company)
        {
            Channel.UpdateCustomer(company);
        }

        public Guid AddCompany(CompanyDTO company)
        {
            return Channel.AddCompany(company);
        }

        public CompanyDTO GetCompanyById(Guid companyId)
        {
            return Channel.GetCompanyById(companyId);
        }

        public CompanyServiceClient(ILoginService loginService) : base(loginService)
        {
        }
    }
}
