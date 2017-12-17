using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpRaven;

namespace ServiceCenter.UI.Infrastructure.Interfaces
{
    public interface ILogExceptionService
    {
        void Log(Exception e);
    }
}
