using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
