﻿using System;
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
            foreach (var x in dto.PricelistItems)
                x.CopyTo(dataModel.Pricelist.FirstOrDefault(m => m.Id == x.Id));
            
            
        }

        public static readonly Expression<Func<Order, OrderDTO>> SelectExpression = u => new OrderDTO
        {
            Id = u.Id,
            Device = u.Device,
            DeviceModel = u.DeviceModel,
            Manufacturer = u.Manufacturer,
            SerialNumber = u.SerialNumber,
            Urgently = u.Urgently,      
            IdUserCreated     = u.IdUserCreated,
            Status = OrderStatusMapper.SelectExpression.Invoke(u.Status),
            PricelistItems = u.Pricelist.Select(x => PriceListMapper.SelectExpression.Invoke(x))
        };
    }

}