using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.UI.Infrastructure.Interfaces
{
    public interface IUserIdService
    {
        void SetCreatorId(Guid? userId);
        Guid GetCreatorId();
    }
}
