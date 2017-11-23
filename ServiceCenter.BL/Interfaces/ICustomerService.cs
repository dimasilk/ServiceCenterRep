using System;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Interfaces
{
    public interface ICustomerService
    {
        CustomerDTO[] GetAllCustomers();
        void DeleteCustomer(Guid clientId);
        void UpdateCustomer(CustomerDTO client);
        Guid AddCustomer(CustomerDTO client);
        CustomerDTO GetCustomerById(Guid clientId);
        //ClientDTO[] GetClientsByUserId(Guid userId);
    }
}
