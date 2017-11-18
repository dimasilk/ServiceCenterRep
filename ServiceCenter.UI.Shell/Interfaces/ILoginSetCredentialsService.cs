using System;

namespace ServiceCenter.UI.Shell.Interfaces
{
    public interface ILoginSetCredentialsService
    {
        void SetCredentials(string userName, string password);
        void SetCreatorId(Guid? userId);
    }
}