using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.UI.Infrastructure.Attributes
{
    public class ModuleInfoAttribute : Attribute
    {
        public ModuleInfoAttribute(string moduleName)
        {
            ModuleName = moduleName;
        }

        public string ModuleName { get; private set; }
    }
}
