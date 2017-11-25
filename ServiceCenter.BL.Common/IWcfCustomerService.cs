

using System;
using System.Diagnostics.Contracts;
using System.ServiceModel;
using System.Threading.Tasks;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Common
{
    [ServiceContract]
    public interface IWcfCustomerService
    {
        [OperationContract]
        Task<CustomerDTO[]> GetAllCustomers();
        [OperationContract]
        void DeleteCustomer(Guid clientId);
        [OperationContract]
        void UpdateCustomer(CustomerDTO client);
        [OperationContract]
        Guid AddCustomer(CustomerDTO client);
        [OperationContract]
        CustomerDTO GetCustomerById(Guid clientId);
    }
}
