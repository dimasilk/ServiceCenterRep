

using System;
using System.Threading.Tasks;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Common
{
    public interface IWcfCustomerService
    {
        Task<CustomerDTO[]> GetAllCustomers();
        void DeleteCustomer(Guid clientId);
        void UpdateCustomer(CustomerDTO client);
        Guid AddCustomer(CustomerDTO client);
        CustomerDTO GetCustomerById(Guid clientId);
    }
}
