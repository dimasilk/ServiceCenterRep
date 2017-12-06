using System;
using System.ServiceModel;
using System.Threading.Tasks;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Common
{
    [ServiceContract]
    public interface IWcfCompanyService
    {
        [OperationContract]
        Task<CompanyDTO[]> GetAllCompanies();
        [OperationContract]
        Task<CompanyDTO[]> GetCompaniesByFilter(CompanyFilterDTO filter);
        [OperationContract]
        void DeleteCompany(Guid companyId);
        [OperationContract]
        void UpdateCompany(CompanyDTO company);
        [OperationContract]
        Guid AddCompany(CompanyDTO company);
        [OperationContract]
        CompanyDTO GetCompanyById(Guid companyId);
    }
}
