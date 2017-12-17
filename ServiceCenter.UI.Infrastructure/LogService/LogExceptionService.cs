using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.UI.Infrastructure.Interfaces;
using SharpRaven;
using SharpRaven.Data;

namespace ServiceCenter.UI.Infrastructure.LogService
{
    public class LogExceptionService : ILogExceptionService
    {
        private readonly RavenClient _ravenClient;
        private readonly ILoginService _loginService;

        public LogExceptionService(RavenClient ravenClient, ILoginService loginService)
        {
            _ravenClient = ravenClient;
            _loginService = loginService;
        }
        public void Log(Exception e)
        {
            var tags = new Dictionary<string, string> { { "UserName", _loginService.GetUserName() } };
            _ravenClient.Capture(new SentryEvent(e) { Tags = tags });
        }
    }
}
