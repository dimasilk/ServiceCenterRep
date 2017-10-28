using System;
using System.Collections.Generic;
using System.ServiceModel;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.WcfService.WcfOrders
{
    [ServiceContract]
    public interface IWcfOrderService
    {

        [OperationContract]
        IEnumerable<OrderDTO> GetAllOrders();
        [OperationContract]
        IEnumerable<OrderDTO> GetOrdersByUserId(Guid userId);
        [OperationContract]
        OrderDTO GetOrderById(Guid orderId);
        [OperationContract]
        void DeleteOrder(Guid orderId);
        [OperationContract]
        void UpdateOrder(OrderDTO orderModel);
        [OperationContract]
        void AddOrder(OrderDTO orderModel);

      
    }


}
