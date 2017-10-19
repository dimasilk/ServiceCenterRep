using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCenter.BL.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.BL.Tests.Common;
using Unity;

namespace ServiceCenter.BL.Tests.OrderServiceTest
{
    [TestClass]
    public class OrderServiceTest : BaseTestClass
    { 
        private readonly OrderDTO orderDto =
            new OrderDTO()
            {
                Manufacturer = "123",
                DeviceModel = "qwer",
                SerialNumber = "1233435",
                Urgently = true,
                Device = "notebook",
                Id = "99E5DFA7-99A9-4F0D-91A5-AA64CFB98709"
            };

        [TestMethod]
        public void ShouldAddAndDeleteOrder()
        {
            var context = Container.Resolve<IOrderService>();
            context.AddOrder(orderDto);
            Assert.IsNotNull(context.GetOrderById("99E5DFA7-99A9-4F0D-91A5-AA64CFB98709"));
            context.DeleteOrder("99E5DFA7-99A9-4F0D-91A5-AA64CFB98709");
            Assert.IsNull(context.GetOrderById("99E5DFA7-99A9-4F0D-91A5-AA64CFB98709"));
        }



    }
}



    