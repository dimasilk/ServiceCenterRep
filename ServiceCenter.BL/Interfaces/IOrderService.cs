using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.BL.DTO;

namespace ServiceCenter.BL.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetAllOrders();
        IEnumerable<OrderDTO> GetOrdersByUserId(string userId);
        OrderDTO GetOrderById(string orderId);
        void DeleteOrder(string orderId);
        void UpdateOrder(OrderDTO orderModel);
        void AddOrder(OrderDTO orderModel);

    }
}
