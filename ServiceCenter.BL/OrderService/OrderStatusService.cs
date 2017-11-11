using System;
using System.Linq;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.BL.Mappings;


namespace ServiceCenter.BL.OrderService
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly ApplicationDbContext _context;
        public OrderStatusService(ApplicationDbContext context)
        {
            _context = context;
        }
        public OrderStatusDTO[] GetAllStatuses()
        {
            return _context.OrderStatuses.Select(OrderStatusMapper.SelectExpression).ToArray();
        }

        public void DeleteOrderStatus(OrderStatusDTO orderStatus)
        {

            if (orderStatus != null)
            {
                var stat = _context.OrderStatuses.FirstOrDefault(x => x.Id == orderStatus.Id);
                if (stat == null) return;
                _context.OrderStatuses.Remove(stat);
                _context.SaveChanges();
            }
            return;
        }

        public void UpdateOrderStatus(OrderStatusDTO orderStatus)
        {
            OrderStatus dataModel = new OrderStatus();
            orderStatus.CopyTo(dataModel);
            _context.Entry(dataModel).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return;
        }

        public Guid AddOrderStatus(OrderStatusDTO orderStatus)
        {
            OrderStatus dataModel = new OrderStatus();
            orderStatus.CopyTo(dataModel);
            _context.OrderStatuses.Add(dataModel);
            _context.SaveChanges();
            return dataModel.Id;
        }

        public OrderStatusDTO GetStatusById(Guid statusId)
        {
             return _context.OrderStatuses.Where(x => x.Id == statusId).Select(OrderStatusMapper.SelectExpression).FirstOrDefault();
        }
    }
}
