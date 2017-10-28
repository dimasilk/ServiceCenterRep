using Microsoft.Practices.Unity;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.BL.OrderService;
using Unity.Wcf;

namespace ServiceCenter.WcfService
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
			// register all your components with the container here
            container
                .RegisterType<IOrderService, OrderService>().RegisterType<ApplicationDbContext>(new PerResolveLifetimeManager());
            //    .RegisterType<DataContext>(new HierarchicalLifetimeManager());
        }
    }    
}