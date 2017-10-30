using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
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
            //    .RegisterType<DataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<IUserStore<ApplicationUser, Guid>, ApplicatonUserStore>();
            container.RegisterType<UserManager<ApplicationUser, Guid>>();
            container.RegisterType<ApplicationDbContext>();
        }
    }    
}