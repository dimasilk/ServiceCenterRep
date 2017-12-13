using System;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure;
using ServiceCenter.UI.Infrastructure.Interfaces;

namespace ServiceCenter.UI.CustomerModule
{
    public class CustomerServiceClient : WcfClientBase<IWcfCustomerService>, IWcfCustomerService
    {
        public Task<CustomerDTO[]> GetAllCustomers()
        {
            return AsyncChannel.ContinueWith(x => x.Result.GetAllCustomers()).Unwrap();
        }

        public Task<CustomerDTO[]> GetCustomersByFilter(CustomerFilterDTO filter)
        {
            return Channel.GetCustomersByFilter(filter);
        }

        public void DeleteCustomer(Guid clientId)
        {
            Channel.DeleteCustomer(clientId);
        }

        public void UpdateCustomer(CustomerDTO client)
        {
            Channel.UpdateCustomer(client);
        }

        public Guid AddCustomer(CustomerDTO client)
        {
            return Channel.AddCustomer(client);
        }

        public CustomerDTO GetCustomerById(Guid clientId)
        {
            return Channel.GetCustomerById(clientId);
        }

        public CustomerServiceClient(ILoginService loginService) : base(loginService)
        {
        }
    }
}
