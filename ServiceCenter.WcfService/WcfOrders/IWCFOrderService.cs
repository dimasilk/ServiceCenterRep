using System.Collections.Generic;
using System.ServiceModel;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;

namespace ServiceCenter.WcfService.WcfOrders
{
    [ServiceContract]
    public interface IWcfOrderService
    {

        [OperationContract]
        IEnumerable<OrderDTO> GetAllOrders();
        [OperationContract]
        IEnumerable<OrderDTO> GetOrdersByUserId(string userId);
        [OperationContract]
        OrderDTO GetOrderById(string orderId);
        [OperationContract]
        void DeleteOrder(string orderId);
        [OperationContract]
        void UpdateOrder(OrderDTO orderModel);
        [OperationContract]
        void AddOrder(OrderDTO orderModel);

      
    }


}
