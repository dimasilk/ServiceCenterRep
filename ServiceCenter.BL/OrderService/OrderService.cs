﻿using System;
using System.Linq;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.BL.Mappings;
using LinqKit;
using System.Data.Entity;
using System.Threading;

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
            //System.Threading.Thread.Sleep(10000);
            return _context.Orders.AsExpandable().Select(OrderMapper.SelectExpression).ToArray();
        }

        public OrderDTO[] GetOrdersByFilter(OrderFilterDTO filter)
        {
            var query = _context.Orders.AsExpandable();
            if (filter.Status != null && filter.Status.Id != Guid.Empty) query = query.Where(x => x.StatusId == filter.Status.Id);
            if (filter.Urgently) query = query.Where(x => x.Urgently);
            if (filter.Customer != null) query = query.Where(x => x.ClientId == filter.Customer.Id);
            if (filter.Company != null) query = query.Where(x => x.CompanyId == filter.Company.Id);
            if (!string.IsNullOrEmpty(filter.SerialNumber))
                query = query.Where(x => x.SerialNumber.Contains(filter.SerialNumber));
            if (filter.FromDateReceived != null) query = query.Where(x => x.DateReceived >= filter.FromDateReceived);
            if (filter.TillDateReceived != null) query = query.Where(x => x.DateReceived <= filter.TillDateReceived);
            return query.Select(OrderMapper.SelectExpression).ToArray();
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

            return _context.Orders.AsExpandable().Where(x => x.Id == orderId).Select(OrderMapper.SelectExpression).FirstOrDefault();
        }

        public void DeleteOrder(Guid orderId)
        {
            var o = _context.Orders.AsExpandable().FirstOrDefault(x => x.Id == orderId);
            if (o != null)
            {
                _context.Orders.Remove(o);
                _context.SaveChanges();
            }

            return;

        }

        public void UpdateOrder(OrderDTO orderModel)
        {
            Order dataModel = _context.Orders.Include(x => x.PricelistOrders).FirstOrDefault(x => x.Id == orderModel.Id);
            if (dataModel == null) return;
            orderModel.CopyTo(dataModel);
            //_context.Entry(dataModel).State = System.Data.Entity.EntityState.Modified;
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
