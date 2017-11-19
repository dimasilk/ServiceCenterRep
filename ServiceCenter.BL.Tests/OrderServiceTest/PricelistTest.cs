using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.BL.Tests.Common;
using Unity;

namespace ServiceCenter.BL.Tests.OrderServiceTest
{
    [TestClass]
    public class PricelistTest : BaseTestClass
    {
        [TestMethod]
        public void PricelistGeneralTest()
        {
            var service = Container.Resolve<IPriceListService>();
            var orderService = Container.Resolve<IOrderService>();
            var userService = Container.Resolve<IUserService>();
            var statusService = Container.Resolve<IOrderStatusService>();
            var user = userService.GetUserById(new Guid("9F09B602-6C46-47D6-9A36-4D0FBDE134C2"));
            var status = statusService.GetStatusById(new Guid("4276A1FD-CAC7-E711-9BD5-1C1B0DF74675"));
            var prices = service.GetFullPriceList();
            var order = new OrderDTO()
            {
                Device = "123",
                DeviceModel = "456",
                IdUserCreated = user.Result.Id,
                Status = status,
                PricelistItems = prices
            };

            orderService.AddOrder(order);
        }
    }
}
