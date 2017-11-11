using System;
using ServiceCenter.UI.Infrastructure.Interfaces;

namespace ServiceCenter.UI.Shell.Login
{
    public class LoginService : ILoginService
    {
        public LoginService()
        {
            #if DEBUG
            _userName = "BLServiceUser";
            _userPassword = "P@ssw0rd1";
            #endif
        }
        private readonly string _userName;
        private readonly string _userPassword;

        public string GetUserName()
        {
            return _userName;
        }

        public string GetUserPassword()
        {
            return _userPassword;
        }
    }
}
