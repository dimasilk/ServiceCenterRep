using System;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure;

namespace ServiceCenter.UI.OrderModule
{
    public class OrderServiceClient : WcfClientBase<IWcfOrderService>, IWcfOrderService
    {
        public OrderDTO[] GetAllOrders()
        {
            return Channel.GetAllOrders();
        }

        public void UpdateOrder(OrderDTO orderModel)
        {
            Channel.UpdateOrder(orderModel);
        }

        public void AddOrder(OrderDTO orderModel)
        {
            Channel.AddOrder(orderModel);
        }

        public void DeleteOrder(Guid orderId)
        {
            Channel.DeleteOrder(orderId);
        }

        public OrderDTO GetOrderById(Guid orderId)
        {
            return Channel.GetOrderById(orderId);
        }

        public OrderDTO[] GetOrdersByUserId(Guid userId)
        {
            return Channel.GetOrdersByUserId(userId);
        }
    }
}
