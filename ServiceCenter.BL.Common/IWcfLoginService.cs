using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.BL.Common
{
    [ServiceContract]
    public interface IWcfLoginService
    {
        [OperationContract]
        Task<bool> IsLogged();
    }
}
