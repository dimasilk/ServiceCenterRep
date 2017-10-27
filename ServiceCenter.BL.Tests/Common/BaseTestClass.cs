using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.DataModels;
using Unity;
using Unity.Lifetime;



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
            if (this.Container != null)
                this.Container.Dispose();
        }



        private void RegisterTypes()
        {
            this.Container.RegisterType<IOrderService, OrderService.OrderService>();
            this.Container.RegisterType<ServiceCenterContext>();
            this.Container.RegisterType<DbContext, ApplicationDbContext>();
            this.Container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            this.Container.RegisterType<UserManager<ApplicationUser>>();
        }
    }
}
