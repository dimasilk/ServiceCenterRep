using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.BL.OrderService;
using ServiceCenter.BL.UserService;
using ServiceCenter.BL.CustomerService;
using ServiceCenter.WcfService.WcfLogin;
using ServiceCenter.WcfService.WcfOrders;
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
            container.RegisterType<IWcfOrderService, WcfOrderService>();
            container.RegisterType<IOrderStatusService, OrderStatusService>();
            container.RegisterType<IWcfLoginService, WcfLoginService>();
            container.RegisterType<IUserIdentityService, UserIdentityService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IPriceListService, PriceListService>();
            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<ICustomerService, CustomerService>();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

        }
    }    
}