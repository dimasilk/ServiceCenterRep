using System;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure;
using ServiceCenter.UI.Infrastructure.Interfaces;

namespace ServiceCenter.UI.OrderModule
{
    public class OrderServiceClient : WcfClientBase<IWcfOrderService>, IWcfOrderService
    {
        public Task<OrderDTO[]> GetAllOrders()
        {
            //return Channel.GetAllOrders();
            
            return AsyncChannel.ContinueWith(x => x.Result.GetAllOrders()).Unwrap();
        }

        public Task<OrderDTO[]> GetOrdersByFilter(OrderFilterDTO filter)
        {
            return AsyncChannel.ContinueWith(x => x.Result.GetOrdersByFilter(filter)).Unwrap();
        }

        public void UpdateOrder(OrderDTO orderModel)
        {
            Channel.UpdateOrder(orderModel);
        }

        public void AddOrder(OrderDTO orderModel)
        {
            Channel.AddOrder(orderModel);
        }

        public Task<OrderStatusDTO[]> GetOrderStatuses()
        {           
           // return Channel.GetOrderStatuses();
            return AsyncChannel.ContinueWith(x => x.Result.GetOrderStatuses()).Unwrap();
        }

        public Task<PricelistDTO[]> GetFullPriceList()
        {
            return Channel.GetFullPriceList();
        }

        public PricelistDTO[] GetPriceListItemsByOrderId(Guid orderId)
        {
            return Channel.GetPriceListItemsByOrderId(orderId);
        }

        public void DeleteOrder(Guid orderId)
        {
            Channel.DeleteOrder(orderId);
        }

        public OrderDTO GetOrderById(Guid orderId)
        {
            return Channel.GetOrderById(orderId);
        }

        public OrderDTO[] GetOrdersByUserId(Guid userId)
        {            
            return Channel.GetOrdersByUserId(userId);
        }

        public OrderServiceClient( ILoginService loginService) : base(loginService)
        {
        }
    }
}
