using System.Collections.Generic;
using System.Linq;
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
            var user = userService.GetUserByLogin("BLServiceUser");
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

            var items = service.GetPriceListItemsByOrder(order.Id);

            var temp = service.GetPriceListItemsByOrder(order.Id);
            order.PricelistItems = new List<PricelistDTO>();
            order.PricelistItems.Add(service.GetFullPriceList().FirstOrDefault());
            orderService.UpdateOrder(order);

            items = service.GetPriceListItemsByOrder(order.Id);

            orderService.DeleteOrder(order.Id);
        }
    }
}
