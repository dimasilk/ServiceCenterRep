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
        private readonly OrderDTO _orderDto =
            new OrderDTO()
            {
                Manufacturer = "123",
                DeviceModel = "qwer",
                SerialNumber = "1233435",
                Urgently = true,
                Device = "notebook",
                Status = new OrderStatusDTO() { Id = new Guid("13E73129-E7AB-43B8-9C18-D0EB480D5848"), StatusValue = "test"}
            };

        [TestMethod]
        public void ShouldAddAndDeleteOrder()
        {
            var service = Container.Resolve<IOrderService>();
            var statusService = Container.Resolve<IOrderStatusService>();
            var pricelistService = Container.Resolve<IPriceListService>();
            var guid = service.AddOrder(_orderDto);
            var order = service.GetOrderById(guid);
            var status = statusService.GetStatusById(order.Status.Id);
            var orders = service.GetAllOrders();
            var x = pricelistService.GetFullPriceList();

            var statuses = statusService.GetAllStatuses();

            Assert.IsTrue(orders.Length > 0);
            Assert.IsNotNull(order);
            Assert.IsNotNull(order.Status);
            Assert.AreEqual(order.SerialNumber, _orderDto.SerialNumber);
            Assert.AreEqual(order.Device, _orderDto.Device);
            Assert.AreEqual(order.DeviceModel, _orderDto.DeviceModel);
            Assert.AreEqual(order.Manufacturer, _orderDto.Manufacturer);
            Assert.AreEqual(order.Urgently, _orderDto.Urgently);
            service.DeleteOrder(guid);
            statusService.DeleteOrderStatus(status);
            Assert.IsNull(service.GetOrderById(guid));
        }



    }
}



    