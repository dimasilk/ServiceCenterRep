using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Mappings
{
    public static class OrderStatusMapper
    {
        public static void CopyTo(this OrderStatusDTO dto, OrderStatus dataModel)
        {
            dataModel.Id = dto.Id;
            dataModel.StatusValue = dto.StatusValue;
        }

        public static readonly Expression<Func<OrderStatus, OrderStatusDTO>> SelectExpression = u => new OrderStatusDTO
        {
            Id = u.Id,
            StatusValue = u.StatusValue
        };
    }
}
