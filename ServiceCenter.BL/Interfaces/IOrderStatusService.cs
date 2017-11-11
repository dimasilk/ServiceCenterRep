using System;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Interfaces
{
    public interface IOrderStatusService
    {
        OrderStatusDTO[] GetAllStatuses();
        void DeleteOrderStatus(OrderStatusDTO orderStatus);
        void UpdateOrderStatus(OrderStatusDTO orderStatus);
        Guid AddOrderStatus(OrderStatusDTO orderStatus);
        OrderStatusDTO GetStatusById(Guid statusId);
    }
}
