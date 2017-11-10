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
        private readonly OrderDTO _orderDto =
            new OrderDTO()
            {
                Manufacturer = "123",
                DeviceModel = "qwer",
                SerialNumber = "1233435",
                Urgently = true,
                Device = "notebook",
                Status = new OrderStatusDTO() { StatusValue="test"}
            };

        [TestMethod]
        public void ShouldAddAndDeleteOrder()
        {
            var service = Container.Resolve<IOrderService>();
            var guid = service.AddOrder(_orderDto);
            var order = service.GetOrderById(guid);
            var orders = service.GetAllOrders();
            Assert.IsTrue(orders.Length > 0);

            Assert.IsNotNull(order);
            Assert.IsNotNull(order.Status);
            Assert.AreEqual(order.SerialNumber, _orderDto.SerialNumber);
            Assert.AreEqual(order.Device, _orderDto.Device);
            Assert.AreEqual(order.DeviceModel, _orderDto.DeviceModel);
            Assert.AreEqual(order.Manufacturer, _orderDto.Manufacturer);
            Assert.AreEqual(order.Urgently, _orderDto.Urgently);
            service.DeleteOrder(guid);
            Assert.IsNull(service.GetOrderById(guid));
        }



    }
}



    