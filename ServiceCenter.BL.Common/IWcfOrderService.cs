using System;
using System.ServiceModel;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Common
{
    [ServiceContract]
    public interface IWcfOrderService
    {

        [OperationContract]
        OrderDTO[] GetAllOrders();
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

      
    }


}
