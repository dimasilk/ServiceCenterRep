using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.BL.Tests.Common;
using Unity;

namespace ServiceCenter.BL.Tests.UserServiceTest
{
    [TestClass]
    public class UserServiceTest : BaseTestClass
    {
        [TestMethod]
        public void UserWorkflow()
        {
            var service = Container.Resolve<IUserService>();
            var user = new ApplicationUser
            {
                UserName = "BLServiceUser",
                Email = "qwer123@oiuy.ui"
            };
            service.AddUser(user, "P@ssw0rd");
            Assert.IsNotNull(service.GetUserById(user.Id).Result);

            user.UserName = "UpdatedUsername";
            service.UpdateUser(user);
            Assert.AreEqual(user.UserName, service.GetUserById(user.Id).Result.UserName);

            service.DeleteUser(user);
            Assert.IsNull(service.GetUserById(user.Id).Result);
        }
    }
}
