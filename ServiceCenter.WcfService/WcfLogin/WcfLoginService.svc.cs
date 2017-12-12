
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Interfaces;

namespace ServiceCenter.WcfService.WcfLogin
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WcfLoginService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы WcfLoginService.svc или WcfLoginService.svc.cs в обозревателе решений и начните отладку.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple, AutomaticSessionShutdown = true)]
    public class WcfLoginService : IWcfLoginService
    {
        private readonly IUserIdentityService _identityService;
        public WcfLoginService(IUserIdentityService identityService)
        {
            _identityService = identityService;
        }

        public Task<Guid?> IsLogged()
        {
            return Task.FromResult(_identityService.GetCurrentUserId());

            //var task = Task.Factory.StartNew(_identityService.GetCurrentUserId());
            //return await task.ConfigureAwait(false);
        }
    }
}
