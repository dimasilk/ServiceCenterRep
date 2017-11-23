using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Interfaces
{
    public interface ICompanyService
    {
        CompanyDTO[] GetAllCompanies();
        void DeleteCompany(Guid companyId);
        void UpdateCompany(CompanyDTO company);
        Guid AddCompany(CompanyDTO company);
        CompanyDTO GetCompanyById(Guid companyId);
        //CompanyDTO[] GetCompaniseByUserId(Guid userId);
    }
}
