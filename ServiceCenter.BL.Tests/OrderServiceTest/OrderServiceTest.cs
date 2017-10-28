using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCenter.BL.Common.DTO;
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
                Device = "notebook"
            };

        [TestMethod]
        public void ShouldAddAndDeleteOrder()
        {
            var service = Container.Resolve<IOrderService>();
            var guid = service.AddOrder(orderDto);
            Assert.IsNotNull(service.GetOrderById(guid));
            service.DeleteOrder(guid);
            Assert.IsNull(service.GetOrderById(guid));
        }



    }
}



    