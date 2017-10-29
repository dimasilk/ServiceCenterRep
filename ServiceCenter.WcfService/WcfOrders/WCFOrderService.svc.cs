using System;
using System.Collections.Generic;
using System.ServiceModel;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;


namespace ServiceCenter.WcfService.WcfOrders
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] 
  
    public class WcfOrderService : IWcfOrderService
    {
        private readonly IOrderService _orderService;
        private readonly ApplicationDbContext _context;
        public WcfOrderService(IOrderService orderService, ApplicationDbContext context)
        {
            _orderService = orderService;
            _context = context;
        }

        public WcfOrderService() { }
       
        public IEnumerable<OrderDTO> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }

        
        public IEnumerable<OrderDTO> GetOrdersByUserId(Guid userId)
        {
            return _orderService.GetOrdersByUserId(userId);
        }

       
        public OrderDTO GetOrderById(Guid orderId)
        {
            return _orderService.GetOrderById(orderId);
        }

       
        public void DeleteOrder(Guid orderId)
        {
            _orderService.DeleteOrder(orderId);
        }


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
