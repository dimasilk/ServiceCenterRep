using System.Security.Cryptography.X509Certificates;

namespace ServiceCenter.UI.Infrastructure.Interfaces
{
    public interface ILoginSetCredentialsService
    {
        void SetCredentials(string userName, string password);
    }
}