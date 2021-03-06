﻿using System;
using System.ServiceModel;
using System.Threading.Tasks;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Common
{
    [ServiceContract]
    public interface IWcfOrderService
    {

        [OperationContract]
        Task<OrderDTO[]> GetAllOrders();
        [OperationContract]
        Task<OrderDTO[]> GetOrdersByFilter(OrderFilterDTO filter);
        [OperationContract]
        OrderDTO[] GetOrdersByUserId(Guid userId);
        [OperationContract]
        OrderDTO GetOrderById(Guid orderId);
        [OperationContract]
        void DeleteOrder(Guid orderId);
        [OperationContract]
        void UpdateOrder(OrderDTO orderModel);
        [OperationContract]
        void AddOrder(OrderDTO orderModel);
        [OperationContract]
        Task<OrderStatusDTO[]> GetOrderStatuses();
        [OperationContract]
        Task<PricelistDTO[]> GetFullPriceList();
        [OperationContract]
        PricelistDTO[] GetPriceListItemsByOrderId(Guid orderId);


    }


}
