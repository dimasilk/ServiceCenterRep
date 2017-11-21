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
            var user = userService.GetUserById(new Guid("6D31CAB9-B1B8-4C40-9FD4-59FA484BF416"));
            var status = statusService.GetAllStatuses().FirstOrDefault();
            var prices = service.GetFullPriceList();
            var item = service.GetPriceListItemById(prices.FirstOrDefault().Id);
            var order = new OrderDTO()
            {
                Device = "123",
                DeviceModel = "456",
                IdUserCreated = user.Result.Id,
                Status = status,
                PricelistItems = prices
            };

            var collection = order.PricelistItems.Select(x => service.GetPriceListItemById(x.Id)).ToList();
            order.PricelistItems = collection;

            order.Id = orderService.AddOrder(order);
            

            order.PricelistItems = new List<PricelistDTO>();
            order.PricelistItems.Add(service.GetFullPriceList().FirstOrDefault());
            orderService.UpdateOrder(order);
            orderService.DeleteOrder(order.Id);
        }
    }
}
