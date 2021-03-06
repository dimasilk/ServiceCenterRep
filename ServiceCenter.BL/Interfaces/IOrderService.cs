﻿using System;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Interfaces
{
    public interface IOrderService
    {
        OrderDTO[] GetAllOrders();
        OrderDTO[] GetOrdersByFilter(OrderFilterDTO filter);
        
        OrderDTO[] GetOrdersByUserId(Guid userId);
        OrderDTO GetOrderById(Guid orderId);
        void DeleteOrder(Guid orderId);
        void UpdateOrder(OrderDTO orderModel);
        Guid AddOrder(OrderDTO orderModel);

    }
}
