using System;
using System.ServiceModel;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;


namespace ServiceCenter.WcfService.WcfOrders
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] 
  
    public class WcfOrderService : IWcfOrderService
    {
        private readonly IOrderService _orderService;
        public WcfOrderService(IOrderService orderService)
        {
            _orderService = orderService;
        }
       
        public async Task<OrderDTO[]> GetAllOrders()
        {
            var task = Task.Factory.StartNew(_orderService.GetAllOrders);
            return await task.ConfigureAwait(false);
        }

        
        public OrderDTO[] GetOrdersByUserId(Guid userId)
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
