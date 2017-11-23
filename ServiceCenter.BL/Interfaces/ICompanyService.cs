using System;
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
