using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.BL.Tests.Common;
using ServiceCenter.DataModels;
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
            var service = Container.Resolve<IOrderService>();
            var context = Container.Resolve<ServiceCenterContext>();
            service.AddOrder(orderDto, context);
            Assert.IsNotNull(service.GetOrderById("99E5DFA7-99A9-4F0D-91A5-AA64CFB98709", context));
            service.DeleteOrder("99E5DFA7-99A9-4F0D-91A5-AA64CFB98709", context);
            Assert.IsNull(service.GetOrderById("99E5DFA7-99A9-4F0D-91A5-AA64CFB98709", context));
        }



    }
}



    