using System;

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
