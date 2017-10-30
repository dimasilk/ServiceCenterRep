using System;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace ServiceCenter.UI.OrderModule
{
    [Module(ModuleName = nameof(OrderModule))]
    public class OrderModule : IModule
    {
        private readonly IUnityContainer _container;
        public OrderModule(IUnityContainer container)
        {
            _container = container;
        }
        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
