using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Interfaces;
using Unity;


namespace ServiceCenter.BL.Tests.Common
{
    [TestClass]
    public abstract class BaseTestClass
    {
        protected IUnityContainer Container;
        [TestInitialize]
        public virtual void InitContainer()
        {
            this.Container = new UnityContainer();
            RegisterTypes();
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            this.Container?.Dispose();
        }


        private void RegisterTypes()
        {
            this.Container.RegisterType<IOrderService, OrderService.OrderService>();
            this.Container.RegisterType<DbContext, ApplicationDbContext>();
            this.Container.RegisterType<IUserStore<ApplicationUser, Guid>, ApplicatonUserStore>();
            this.Container.RegisterType<UserManager<ApplicationUser, Guid>>();
            this.Container.RegisterType<ApplicationDbContext>();
            this.Container.RegisterType<IUserService, UserService.UserService>();
        }
    }
}
