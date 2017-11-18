using System;
using ServiceCenter.UI.Infrastructure.Interfaces;
using ServiceCenter.UI.Shell.Interfaces;

namespace ServiceCenter.UI.Shell.Login
{
    public class LoginService : ILoginService, ILoginSetCredentialsService, IUserIdService
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
        private Guid _creatorId;

        public string GetUserName()
        {
            return _userName;
        }

        public string GetUserPassword()
        {
            return _userPassword;
        }

        public Guid GetCreatorId()
        {
            return _creatorId;
        }

        public void SetCredentials(string userName, string password)
        {
            _userName = userName;
            _userPassword = password;
        }

        public void SetCreatorId(Guid? userId)
        {
            if (userId != Guid.Empty) _creatorId = (Guid)userId;
        }
    }
}
