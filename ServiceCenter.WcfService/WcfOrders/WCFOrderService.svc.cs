using System;
using System.ServiceModel;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;


namespace ServiceCenter.WcfService.WcfOrders
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple, AutomaticSessionShutdown = true)]

    public class WcfOrderService : IWcfOrderService
    {
        private readonly IOrderService _orderService;
        private readonly IOrderStatusService _statusService;
        private readonly IPriceListService _priceListService;

        public WcfOrderService(IOrderService orderService, IOrderStatusService statusService, IPriceListService priceListService)
        {
            _orderService = orderService;
            _statusService = statusService;
            _priceListService = priceListService;
        }

        public async Task<OrderDTO[]> GetAllOrders()
        {
            var task = Task.Factory.StartNew(_orderService.GetAllOrders);
            return await task.ConfigureAwait(false);
        }

        public async Task<OrderDTO[]> GetOrdersByFilter(OrderFilterDTO filter)
        {
            var task = Task.Factory.StartNew(() => _orderService.GetOrdersByFilter(filter));
            return await task.ConfigureAwait(false);
        }

        public async Task<PricelistDTO[]> GetFullPriceList()
        {
            var task = Task.Factory.StartNew(_priceListService.GetFullPriceList);
            return await task.ConfigureAwait(false);
        }

        public PricelistDTO[] GetPriceListItemsByOrderId(Guid orderId)
        {
            return _priceListService.GetPriceListItemsByOrder(orderId);
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

        public async Task<OrderStatusDTO[]> GetOrderStatuses()
        {
            var task = Task.Factory.StartNew(_statusService.GetAllStatuses);
            return await task.ConfigureAwait(false);
        }
    }
}
