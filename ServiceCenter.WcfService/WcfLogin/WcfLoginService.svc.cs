
using System;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Interfaces;

namespace ServiceCenter.WcfService.WcfLogin
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WcfLoginService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы WcfLoginService.svc или WcfLoginService.svc.cs в обозревателе решений и начните отладку.
    public class WcfLoginService : IWcfLoginService
    {
        private readonly IUserIdentityService _identityService;
        public WcfLoginService(IUserIdentityService identityService)
        {
            _identityService = identityService;
        }

        public Task<Guid?> IsLogged()
        {
            //var a = _identityService.GetCurrentUserId();
            //return a;
            return Task.FromResult(_identityService.GetCurrentUserId());
        }
    }
}
