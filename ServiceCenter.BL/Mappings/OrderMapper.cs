using System;
using System.Linq;
using System.Linq.Expressions;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Common.DTO;
using LinqKit;

namespace ServiceCenter.BL.Mappings
{
    public static class OrderMapper
    {
        public static void CopyTo(this OrderDTO dto, Order dataModel)
        {
            dataModel.Id = dto.Id;
            dataModel.Device = dto.Device;
            dataModel.Manufacturer = dto.Manufacturer;
            dataModel.SerialNumber = dto.SerialNumber;
            dataModel.Urgently = dto.Urgently;
            dataModel.DeviceModel = dto.DeviceModel;
            dataModel.IdUserCreated = dto.IdUserCreated;
            dataModel.StatusId = dto.Status.Id;
            dataModel.DateRecieved = dto.DateRecieved;
            dataModel.DateOrderReady = dto.DateReady;
            dataModel.OrderAmount = dto.OrderAmount;
            dataModel.PriceCoefficient = dto.PriceCoefficient;
            if (dto.Customer != null) dataModel.ClientId = dto.Customer.Id;
            if (dto.Company != null) dataModel.CompanyId = dto.Company.Id;
            dataModel.PricelistOrders.Clear();
            
            foreach (var x in dto.PricelistItems)
            {
                dataModel.PricelistOrders.Add(new PricelistOrders()
                {
                    Order = dataModel,
                    Pricelist_Id = x.Id
                });   
            }

        }

        public static readonly Expression<Func<Order, OrderDTO>> SelectExpression = u => new OrderDTO
        {
            Id = u.Id,
            Device = u.Device,
            DeviceModel = u.DeviceModel,
            Manufacturer = u.Manufacturer,
            SerialNumber = u.SerialNumber,
            Urgently = u.Urgently,
            IdUserCreated = u.IdUserCreated,
            OrderAmount = u.OrderAmount,
            PriceCoefficient = u.PriceCoefficient,
            DateReady = u.DateOrderReady,
            DateRecieved = u.DateRecieved,
            Status = OrderStatusMapper.SelectExpression.Invoke(u.Status),
            PricelistItems =
                u.PricelistOrders.Select(x => PriceListMapper.SelectExpression.Invoke(x.Pricelist)).ToList(),
            Customer = u.Client != null ? CustomerMapper.SelectExpression.Invoke(u.Client) : null,
            Company = u.Company != null ? CompanyMapper.SelectExpression.Invoke(u.Company) : null

        };
    }

}