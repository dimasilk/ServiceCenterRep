using System;
using System.Collections.Generic;
using System.ServiceModel;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.DataModels;

namespace ServiceCenter.WcfService.WcfOrders
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] 
    [ServiceContract]
    public class WcfOrderService : IWcfOrderService
    {
        private readonly IOrderService _orderService;
        private readonly ServiceCenterContext _context;
        public WcfOrderService(IOrderService orderService, ServiceCenterContext context)
        {
            _orderService = orderService;
            _context = context;
        }
        [OperationContract]
        public IEnumerable<OrderDTO> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }

        [OperationContract]
        public IEnumerable<OrderDTO> GetOrdersByUserId(string userId)
        {
            return _orderService.GetOrdersByUserId(userId);
        }

        [OperationContract]
        public OrderDTO GetOrderById(string orderId)
        {
            return _orderService.GetOrderById(orderId);
        }

        [OperationContract]
        public void DeleteOrder(string orderId)
        {
            _orderService.DeleteOrder(orderId);
        }

        [OperationContract]
        public void UpdateOrder(OrderDTO orderModel)
        {
            _orderService.UpdateOrder(orderModel);
        }

        public void AddOrder(OrderDTO orderModel)
        {
            _orderService.AddOrder(orderModel);
        }
        
    }
}
