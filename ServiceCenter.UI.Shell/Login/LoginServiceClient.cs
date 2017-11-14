using System;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.UI.Infrastructure;
using ServiceCenter.UI.Infrastructure.Interfaces;

namespace ServiceCenter.UI.Shell.Login
{
    public class LoginServiceClient : WcfClientBase<IWcfLoginService>, IWcfLoginService
    {
        public LoginServiceClient(ILoginService loginService) : base(loginService)
        {
        }

        public  Task<Guid?> IsLogged()
        {
            return Channel.IsLogged();
        }
    }
}
