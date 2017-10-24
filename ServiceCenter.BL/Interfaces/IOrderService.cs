using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.BL.DTO;
using ServiceCenter.DataModels;

namespace ServiceCenter.BL.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetAllOrders(ServiceCenterContext context);
        IEnumerable<OrderDTO> GetOrdersByUserId(string userId, ServiceCenterContext context);
        OrderDTO GetOrderById(string orderId, ServiceCenterContext context);
        void DeleteOrder(string orderId, ServiceCenterContext context);
        void UpdateOrder(OrderDTO orderModel, ServiceCenterContext context);
        void AddOrder(OrderDTO orderModel, ServiceCenterContext context);

    }
}
