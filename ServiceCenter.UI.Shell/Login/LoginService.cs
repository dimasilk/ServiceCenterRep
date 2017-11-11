using ServiceCenter.UI.Infrastructure.Interfaces;

namespace ServiceCenter.UI.Shell.Login
{
    public class LoginService : ILoginService, ILoginSetCredentialsService
    {
        public LoginService()
        {
            #if DEBUG
            _userName = "BLServiceUser";
            _userPassword = "P@ssw0rd";
            #endif
        }
        private string _userName;
        private string _userPassword;

        public string GetUserName()
        {
            return _userName;
        }

        public string GetUserPassword()
        {
            return _userPassword;
        }

        public void SetCredentials(string userName, string password)
        {
            _userName = userName;
            _userPassword = password;
        }
    }
}
