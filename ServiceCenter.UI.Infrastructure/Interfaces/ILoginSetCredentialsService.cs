using System;

namespace ServiceCenter.UI.Infrastructure.Interfaces
{
    public interface ILoginSetCredentialsService
    {
        void SetCredentials(string userName, string password);
        void SetCreatorId(Guid? userId);
    }
}