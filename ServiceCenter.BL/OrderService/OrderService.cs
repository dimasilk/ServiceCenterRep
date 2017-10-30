using System;
using System.Linq;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.BL.Mappings;


namespace ServiceCenter.BL.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public OrderDTO[] GetAllOrders()
        {
            return _context.Orders.Select(OrderMapper.SelectExpression).ToArray();
        }

        public OrderDTO[] GetOrdersByUserId(Guid userId)
        {
            /*  using (var context = new ServiceCenterContext())
              {
                  var res = context.Orders.Where(x => x.userId = userId);
                  return res?.Select(x => new OrderDTO(x)).ToList();
              }*/
            throw new NotImplementedException();
        }

        public OrderDTO GetOrderById(Guid orderId)
        {

            return _context.Orders.Where(x => x.Id == orderId).Select(OrderMapper.SelectExpression).FirstOrDefault();
        }

        public void DeleteOrder(Guid orderId)
        {
            var o = _context.Orders.FirstOrDefault(x => x.Id == orderId);
            if (o != null)
            {
                _context.Orders.Remove(o);
                _context.SaveChanges();
            }

            return;

        }

        public void UpdateOrder(OrderDTO orderModel)
        {
            Order dataModel = new Order();
            orderModel.CopyTo(dataModel);
            _context.Entry(dataModel).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return;

        }

        public Guid AddOrder(OrderDTO orderModel)
        {
            Order dataModel = new Order();
            orderModel.CopyTo(dataModel);
            _context.Orders.Add(dataModel);
            _context.SaveChanges();
            return dataModel.Id;
        }
    }
}
