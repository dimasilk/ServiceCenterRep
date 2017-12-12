using System;
using System.ServiceModel;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;

namespace ServiceCenter.WcfService.WcfCustomers
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WcfCustomerService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы WcfCustomerService.svc или WcfCustomerService.svc.cs в обозревателе решений и начните отладку.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple, AutomaticSessionShutdown = true)]
    public class WcfCustomerService : IWcfCustomerService
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly ICompanyService _companyService;

        public WcfCustomerService(ICompanyService companyService, ICustomerService customerService, IOrderService orderService)
        {
            _companyService = companyService;
            _customerService = customerService;
            _orderService = orderService;
        }

        public async Task<CustomerDTO[]> GetAllCustomers()
        {
            var task = Task.Factory.StartNew(_customerService.GetAllCustomers);
            return await task.ConfigureAwait(false);
        }

        public async Task<CustomerDTO[]> GetCustomersByFilter(CustomerFilterDTO filter)
        {
            var task = Task.Factory.StartNew(() => _customerService.GetCustomersByFilter(filter));
            return await task.ConfigureAwait(false);
        }

        public void DeleteCustomer(Guid clientId)
        {
            _customerService.DeleteCustomer(clientId);
        }

        public void UpdateCustomer(CustomerDTO client)
        {
            _customerService.UpdateCustomer(client);
        }

        public Guid AddCustomer(CustomerDTO client)
        {
            return _customerService.AddCustomer(client);
        }

        public CustomerDTO GetCustomerById(Guid clientId)
        {
            return _customerService.GetCustomerById(clientId);
        }
    }
}
