using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ServiceCenter.BL.Common
{
    [ServiceContract]
    public interface IWcfLoginService
    {
        [OperationContract]
        Task<Guid?> IsLogged();
    }
}
