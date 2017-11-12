using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
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

        public Task<bool> IsLogged()
        {
            return Channel.IsLogged();
        }
    }
}
