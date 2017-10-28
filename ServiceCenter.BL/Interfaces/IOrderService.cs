using System;
using System.Collections.Generic;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetAllOrders();
        IEnumerable<OrderDTO> GetOrdersByUserId(Guid userId);
        OrderDTO GetOrderById(Guid orderId);
        void DeleteOrder(Guid orderId);
        void UpdateOrder(OrderDTO orderModel);
        Guid AddOrder(OrderDTO orderModel);

    }
}
