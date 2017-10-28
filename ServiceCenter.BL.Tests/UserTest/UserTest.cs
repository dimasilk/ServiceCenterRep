using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Tests.Common;
using Unity;

namespace ServiceCenter.BL.Tests.UserTest
{
    [TestClass]
    public class UserTest : BaseTestClass
    {
        [TestMethod]
        public void ShouldAddUser()
        {
            var um = Container.Resolve<UserManager<ApplicationUser>>();
            var user = new ApplicationUser
            {
                Email = "testemail@yandex.ru",
                UserName = "Nickname"
            };
            var userIdentity = um.Create(user, "testpass322");
            Assert.IsTrue(userIdentity.Succeeded);
            Assert.IsFalse(um.CheckPassword(user, "wrongpass322"));
            Assert.IsTrue(um.CheckPassword(user, "testpass322"));
            userIdentity = um.Delete(user);
            Assert.IsTrue(userIdentity.Succeeded);
        }
    }
}

