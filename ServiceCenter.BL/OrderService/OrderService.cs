using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.BL.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.DataModels;


namespace ServiceCenter.BL.OrderService
{
    public class OrderService : IOrderService
    {
        public IEnumerable<DTO.OrderDTO> GetAllOrders(ServiceCenterContext context)
        {
            var res = context.Orders.ToList();
            if (res != null) return res.Select(x => new OrderDTO(x)).ToList();

            return null;
        }

        public IEnumerable<DTO.OrderDTO> GetOrdersByUserId(string userId, ServiceCenterContext context)
        {
            /*  using (var context = new ServiceCenterContext())
              {
                  var res = context.Orders.Where(x => x.userId = userId);
                  return res?.Select(x => new OrderDTO(x)).ToList();
              }*/
            throw new NotImplementedException();
        }

        public DTO.OrderDTO GetOrderById(string orderId, ServiceCenterContext context)
        {

            var res = context.Orders.Find(orderId);
            if (res != null) return new OrderDTO(res);

            return null;
        }

        public void DeleteOrder(string orderId, ServiceCenterContext context)
        {

            var o = context.Orders.FirstOrDefault(x => x.Id == orderId);
            if (o != null)
            {
                context.Orders.Remove(o);
                context.SaveChanges();
            }

            /*OrderDataModel dataModel = new OrderDataModel();
            GetOrderById(orderId, context).CopyTo(dataModel);
            //context.Orders.Remove(dataModel);
            context.Entry(dataModel).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();*/
            return;

        }

        public void UpdateOrder(DTO.OrderDTO orderModel, ServiceCenterContext context)
        {
            OrderDataModel dataModel = new OrderDataModel();
            orderModel.CopyTo(dataModel);
            context.Entry(dataModel).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return;

        }

        public void AddOrder(DTO.OrderDTO orderModel, ServiceCenterContext context)
        {

            OrderDataModel dataModel = new OrderDataModel();
            orderModel.CopyTo(dataModel);
            context.Orders.Add(dataModel);
            context.SaveChanges();
            return;


        }
    }
}
