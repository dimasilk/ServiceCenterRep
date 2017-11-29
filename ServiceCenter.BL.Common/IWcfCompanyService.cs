using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
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
        void DeleteCompany(Guid companyId);
        [OperationContract]
        void UpdateCustomer(CompanyDTO company);
        [OperationContract]
        Guid AddCompany(CompanyDTO company);
        [OperationContract]
        CompanyDTO GetCompanyById(Guid companyId);
    }
}
