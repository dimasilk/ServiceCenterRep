using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure;

namespace ServiceCenter.UI.CustomerModule
{
    public class CustomerServiceClient : IWcfCustomerService
    {
        public Task<CustomerDTO[]> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(CustomerDTO client)
        {
            throw new NotImplementedException();
        }

        public Guid AddCustomer(CustomerDTO client)
        {
            throw new NotImplementedException();
        }

        public CustomerDTO GetCustomerById(Guid clientId)
        {
            throw new NotImplementedException();
        }
    }
}
